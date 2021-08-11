using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Vulder.Admin.Api.Controllers.User
{
    [ApiController]
    [Route("user/[controller]")]
    public class CreateController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public CreateController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Core.Models.User userCreate)
        {
            var user = await _mediator.Send(
                new Core.ProjectAggregate.User.User(userCreate.Email)
                    .CreateTimestamp()
                    .GenerateGuid()
                    .GeneratePasswordHash(userCreate.Password)
            );
            
            return Ok(user);
        }
    }
}
