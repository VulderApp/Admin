using MediatR;
using Vulder.Admin.Core.Exceptions;
using Vulder.Admin.Core.Models;
using Vulder.Admin.Core.ProjectAggregate.User.Dtos;
using Vulder.Admin.Core.Utils;
using Vulder.Admin.Infrastructure.Database.Interfaces;

namespace Vulder.Admin.Application.Admin.Password;

public class ChangePasswordRequestHandler : IRequestHandler<ChangePasswordRequestModel, ResultDto>
{
    private readonly IUserRepository _userRepository;

    public ChangePasswordRequestHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ResultDto> Handle(ChangePasswordRequestModel request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUser(request.Email!);

        if (!PasswordUtil.VerifyPassword(request.CurrentPassword!, user!.Password!))
            throw new AuthException("Password is incorrect");

        user.Password = PasswordUtil.GetEncryptedPassword(request.NewPassword!);
        await _userRepository.UpdateUser(user);

        return new ResultDto
        {
            Result = true
        };
    }
}