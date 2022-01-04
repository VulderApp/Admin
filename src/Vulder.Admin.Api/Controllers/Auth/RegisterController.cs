using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vulder.Admin.Core.Models;

namespace Vulder.Admin.Api.Controllers.Auth;

[ApiController]
[Route("/auth/[controller]")]
public class RegisterController : ControllerBase
{
    private readonly IMediator _mediator;

    public RegisterController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterUserModel registerUserModel)
    {
        var result = await _mediator.Send(registerUserModel);

        return Ok(result);
    }
}