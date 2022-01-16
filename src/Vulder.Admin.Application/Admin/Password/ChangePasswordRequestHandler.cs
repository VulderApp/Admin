using MediatR;
using Vulder.Admin.Core.Models;
using Vulder.Admin.Core.Utils;
using Vulder.Admin.Infrastructure.Database.Interfaces;

namespace Vulder.Admin.Application.Admin.Password;

public class ChangePasswordRequestHandler : IRequestHandler<ChangePasswordRequestModel, bool>
{
    private readonly IUserRepository _userRepository;
    
    public ChangePasswordRequestHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public async Task<bool> Handle(ChangePasswordRequestModel request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUser(request.Email!);

        if (!PasswordUtil.VerifyPassword(request.CurrentPassword!, user!.Password!)) return false;

        user.Password = PasswordUtil.GetEncryptedPassword(request.NewPassword!);
        await _userRepository.UpdateUser(user);

        return false;
    }
}