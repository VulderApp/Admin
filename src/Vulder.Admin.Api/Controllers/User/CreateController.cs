using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Vulder.Admin.Api.Controllers.User
{
    [ApiController]
    [Authorize]
    [Route("user/[controller]")]
    public class CreateController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public CreateController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Core.Models.User userModel)
        {
            var user = await _mediator.Send(
                new Core.ProjectAggregate.User.User(userModel.Email)
                    .CreateTimestamp()
                    .GenerateGuid()
                    .GeneratePasswordHash(userModel.Password)
            );
            
            
            return Ok(user);
        }
    }
}
