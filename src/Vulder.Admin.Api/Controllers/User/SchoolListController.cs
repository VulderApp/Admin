using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Vulder.Admin.Api.Controllers.User
{
    [Authorize]
    [ApiController]
    [Route("user/[controller]")]
    public class SchoolListController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(User.FindFirst(ClaimTypes.Email)?.Value);
        }
    }
}