using System;
using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vulder.Admin.Core.Models;
using Vulder.Admin.Core.ProjectAggregate.SchoolForm;

namespace Vulder.Admin.Api.Controllers.School.Form
{
    [Authorize]
    [ApiController]
    [Route("school/form/[controller]")]
    public class RegisterSchoolFormController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public RegisterSchoolFormController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> PostSchoolForm([FromBody] SchoolFormModel schoolFormModel)
        {
            var id = User.FindFirst(ClaimTypes.PrimarySid)?.Value;
            if (id == null) 
                return Problem("Token has broken payload. Please log in again!");
            
            var school = new SchoolForm
            {
                RequesterId = new Guid(id),
                SchoolName = schoolFormModel.SchoolName,
                TimetableUrl = schoolFormModel.TimetableUrl,
                SchoolUrl = schoolFormModel.SchoolUrl
            }.GenerateId().CreateTimestamp();
            var result = await _mediator.Send(school);

            if (!result)
                return Problem("Couldn't register school form to db!");

            return Ok();
        }
    }
}