using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vulder.Admin.Core.Models;

namespace Vulder.Admin.Api.Controllers.User
{
    [Authorize]
    [ApiController]
    [Route("user/[controller]")]
    public class SchoolListController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public SchoolListController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var schoolsDto = await _mediator.Send(new JwtModel
            {
                Id = User.FindFirst(ClaimTypes.Sid)?.Value,
                Email = User.FindFirst(ClaimTypes.Email)?.Value
            });
            
            return Ok(schoolsDto);
        }
    }
}