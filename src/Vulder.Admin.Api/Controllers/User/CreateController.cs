using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vulder.Admin.Api.Models;
using Vulder.Admin.Infrastructure.Data;
using Vulder.Admin.Infrastructure.Handlers.User;

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
        public async Task<IActionResult> Post([FromBody]UserCreate userCreate)
        {
            var user = await _mediator.Send(new Core.ProjectAggregate.User.User().CreateTimestamp().GenerateGuid());
            return Ok(user);
        }
    }
}
