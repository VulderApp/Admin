﻿using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vulder.Admin.Core.Interfaces;

namespace Vulder.Admin.Api.Controllers.User
{
    [ApiController]
    [Route("user/[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IJwtService _jwtService;

        public RegisterController(IMediator mediator, IJwtService jwtService)
        {
            _mediator = mediator;
            _jwtService = jwtService;
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Core.Models.UserModel userModel)
        {
            var user = await _mediator.Send(
                new Core.ProjectAggregate.User.User(userModel.Email)
                    .CreateTimestamp()
                    .GenerateGuid()
                    .GeneratePasswordHash(userModel.Password)
            );
            
            return Ok(_jwtService.GetGeneratedJwtToken(user));
        }
    }
}
