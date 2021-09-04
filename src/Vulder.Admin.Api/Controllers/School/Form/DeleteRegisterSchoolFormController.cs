using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vulder.Admin.Core.Models;

namespace Vulder.Admin.Api.Controllers.School.Form
{
    [Authorize]
    [ApiController]
    [Route("school/form/[controller]")]
    public class DeleteRegisterSchoolFormController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public DeleteRegisterSchoolFormController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpDelete]
        public async Task<IActionResult> DeleteForm([FromQuery(Name = "formId")] string formId)
        {
            var id = User.FindFirst(ClaimTypes.PrimarySid)?.Value;
            
            if (string.IsNullOrEmpty(id))
                return BadRequest("Token has broken payload. Please log in again!");
            if (string.IsNullOrEmpty(formId))
                return BadRequest("formId is null or empty");

            await _mediator.Send(new JwtModel
            {
                Id = id
            });
            
            return Ok();
        }
    }
}