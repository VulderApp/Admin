using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vulder.Admin.Core.Interfaces;

namespace Vulder.Admin.Api.Controllers.User
{
    [ApiController]
    [Route("user/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IJwtService _jwtService;
        
        public LoginController(IMediator mediator, IJwtService jwtService)
        {
            _mediator = mediator;
            _jwtService = jwtService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Core.Models.UserModel user)
        {
            var userDto = await _mediator.Send(user);
            return Ok(_jwtService.GetGeneratedJwtToken(userDto));
        }
    }
}