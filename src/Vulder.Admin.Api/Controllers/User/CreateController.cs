using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Vulder.Admin.Api.Controllers.User
{
    [ApiController]
    [Route("user/[controller]")]
    public class CreateController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post()
        {
            return Ok();
        }
    }
}
