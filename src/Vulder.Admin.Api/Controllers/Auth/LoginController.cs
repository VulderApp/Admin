using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vulder.Admin.Core.Models;

namespace Vulder.Admin.Api.Controllers.Auth;

[ApiController]
[Route("/auth/login")]
public class LoginController : ControllerBase
{
    private readonly IMediator _mediator;

    public LoginController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginUserModel loginUserModel)
    {
        var result = await _mediator.Send(loginUserModel);

        return Ok(result);
    }
}