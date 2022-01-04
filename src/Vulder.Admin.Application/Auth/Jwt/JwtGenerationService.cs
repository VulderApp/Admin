using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Vulder.Admin.Core.Configuration;
using Vulder.Admin.Core.ProjectAggregate.User;

namespace Vulder.Admin.Application.Auth.Jwt;

public class JwtGenerationService : IJwtGenerationService
{
    private readonly IJwtConfiguration _authConfiguration;

    public JwtGenerationService(IJwtConfiguration configuration)
    {
        _authConfiguration = configuration;
    }

    public string GetGeneratedJwtToken(User userDto)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.PrimarySid, userDto.Id.ToString()),
                new Claim(ClaimTypes.Email, userDto.Email),
                new Claim(ClaimTypes.Role, userDto.Role.ToString())
            }),
            Expires = DateTime.UtcNow.AddMinutes(30),
            Issuer = _authConfiguration.Issuer,
            Audience = _authConfiguration.Audience,
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_authConfiguration.Key)
                ),
                SecurityAlgorithms.HmacSha256Signature
            )
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}