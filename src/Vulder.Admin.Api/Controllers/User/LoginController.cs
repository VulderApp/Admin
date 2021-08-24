using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vulder.Admin.Core.Interfaces;

namespace Vulder.Admin.Api.Controllers.User
{
    [ApiController]
    [Route("user/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IJwtGenerationService _jwtGenerationService;
        
        public LoginController(IMediator mediator, IJwtGenerationService jwtGenerationService)
        {
            _mediator = mediator;
            _jwtGenerationService = jwtGenerationService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Core.Models.User user)
        {
            var userDto = await _mediator.Send(user);
            return Ok(_jwtGenerationService.GetGeneratedJwtToken(userDto));
        }
    }
}