using MediatR;
using Vulder.Admin.Application.Auth.Jwt;
using Vulder.Admin.Core;
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
        if (Constants.RegisterOnlyOneAccount())
        {
            var userCount = await _userRepository.GetUserCount();
            if (userCount > 0) throw new Exception("Couldn't register next account because 1 account is exists");
        }
        
        var user = new Core.ProjectAggregate.User.User
        {
            Email = request.Email,
            Password = PasswordUtil.GetEncryptedPassword(request.Password!)
        }.GenerateId().CreateTimestamp().UpdateTimestamp();

        var userDb = await _userRepository.CreateUser(user);

        return new AuthUserDto
        {
            Token = _jwtService.GetGeneratedJwtToken(userDb)
        };
    }
}