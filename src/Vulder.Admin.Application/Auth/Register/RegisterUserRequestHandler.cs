using MediatR;
using Vulder.Admin.Application.Auth.Jwt;
using Vulder.Admin.Core.Models;
using Vulder.Admin.Core.ProjectAggregate.User.Dtos;
using Vulder.Admin.Core.Utils;
using Vulder.Admin.Infrastructure.Database.Interfaces;

namespace Vulder.Admin.Application.Auth.Register;

public class RegisterUserRequestHandler : IRequestHandler<RegisterUserModel, AuthUserDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtGenerationService _jwtService;

    public RegisterUserRequestHandler(IUserRepository userRepository, IJwtGenerationService jwtService)
    {
        _userRepository = userRepository;
        _jwtService = jwtService;
    }

    public async Task<AuthUserDto> Handle(RegisterUserModel request, CancellationToken cancellationToken)
    {
        var user = new Core.ProjectAggregate.User.User
        {
            Email = request.Email,
            Password = PasswordUtil.GetEncryptedPassword(request.Password)
        }.GenerateId().CreateTimestamp();

        var userDb = await _userRepository.CreateUser(user);

        return new AuthUserDto
        {
            Token = _jwtService.GetGeneratedJwtToken(userDb)
        };
    }
}