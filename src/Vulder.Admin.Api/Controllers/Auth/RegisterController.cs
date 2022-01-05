using MediatR;
using Microsoft.AspNetCore.Mvc;
using Vulder.Admin.Core.Models;
using Vulder.Admin.Infrastructure.Database.Interfaces;

namespace Vulder.Admin.Api.Controllers.Auth;

[ApiController]
[Route("/auth/[controller]")]
public class RegisterController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterController(IMediator mediator, IUnitOfWork unitOfWork)
    {
        _mediator = mediator;
        _unitOfWork = unitOfWork;
    }

    [HttpPost]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterUserModel registerUserModel)
    {
        var result = await _mediator.Send(registerUserModel);

        await _unitOfWork.CompleteAsync();

        return Ok(result);
    }
}