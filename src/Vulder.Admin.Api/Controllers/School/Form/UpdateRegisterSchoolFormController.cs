using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vulder.Admin.Core.Models;

namespace Vulder.Admin.Api.Controllers.School.Form
{
    
    [ApiController]
    [Route("school/form/[controller]")]
    public class UpdateRegisterSchoolFormController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public UpdateRegisterSchoolFormController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> UpdateForm([FromBody] UpdateFormModel schoolFormModel)
        {
            await _mediator.Send(schoolFormModel);
            return Ok();
        }
    }
}