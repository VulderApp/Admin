using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Vulder.Admin.Core.Interfaces;
using Vulder.Admin.Core.ProjectAggregate.User;

namespace Vulder.Admin.Core.Services
{
    public class JwtService : IJwtService
    {
        private readonly IAuthConfiguration _authConfiguration;

        public JwtService(IAuthConfiguration configuration)
        {
            _authConfiguration = configuration;
        }

        public string GetGeneratedJwtToken(UserDto userDto)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.PrimarySid, userDto.Id.ToString()),
                    new Claim(ClaimTypes.Email, userDto.Email)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
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
}