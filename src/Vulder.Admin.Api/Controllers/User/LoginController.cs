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
        private readonly IJwtService _jwtService;
        private readonly IMediator _mediator;


        public LoginController(IMediator mediator, IJwtService jwtService)
        {
            _mediator = mediator;
            _jwtService = jwtService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Core.Models.User user)
        {
            var userDto = await _mediator.Send(user);
            return Ok(_jwtService.GetGeneratedToken(userDto));
        }
    }
}