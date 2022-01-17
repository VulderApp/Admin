using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Vulder.Admin.Core.Models;
using Vulder.Admin.Infrastructure.Database.Interfaces;

namespace Vulder.Admin.Api.Controllers.Admin;

[Authorize]
[ApiController]
[Route("/admin/[controller]")]
public class ChangePasswordController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IUnitOfWork _unitOfWork;

    public ChangePasswordController(IMediator mediator, IUnitOfWork unitOfWork)
    {
        _mediator = mediator;
        _unitOfWork = unitOfWork;
    }

    [HttpPut]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordModel changePasswordModel)
    {
        var result = await _mediator.Send(new ChangePasswordRequestModel
        {
            CurrentPassword = changePasswordModel.CurrentPassword,
            NewPassword = changePasswordModel.NewPassword,
            Id = Guid.Parse(User.FindFirst(ClaimTypes.PrimarySid)?.Value!),
            Email = User.FindFirst(ClaimTypes.Email)?.Value!
        });

        await _unitOfWork.CompleteAsync();

        return Ok(result);
    }
}