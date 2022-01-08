using MediatR;
using Vulder.Admin.Application.Auth.Jwt;
using Vulder.Admin.Core.Exceptions;
using Vulder.Admin.Core.Models;
using Vulder.Admin.Core.ProjectAggregate.User.Dtos;
using Vulder.Admin.Core.Utils;
using Vulder.Admin.Infrastructure.Database.Interfaces;

namespace Vulder.Admin.Application.Auth.Login;

public class LoginUserRequestHandler : IRequestHandler<LoginUserModel, AuthUserDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtGenerationService _jwtGenerationService;

    public LoginUserRequestHandler(IUserRepository userRepository, IJwtGenerationService jwtGenerationService)
    {
        _userRepository = userRepository;
        _jwtGenerationService = jwtGenerationService;
    }

    public async Task<AuthUserDto> Handle(LoginUserModel request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUser(request.Email!);
        if (user == null) throw new AuthException("User not found");

        if (!PasswordUtil.VerifyPassword(request.Password!, user.Password!))
            throw new AuthException("The password is incorrect");

        return new AuthUserDto
        {
            Token = _jwtGenerationService.GetGeneratedJwtToken(user)
        };
    }
}