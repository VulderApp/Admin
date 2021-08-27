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
        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetGeneratedJwtToken(UserDto userDto)
        {
            var auth = _configuration.GetSection("Auth");
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("id", userDto.Id.ToString()),
                    new Claim(ClaimTypes.Email, userDto.Email)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                Issuer = auth["Issuer"],
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(auth["Key"])
                    ),
                    SecurityAlgorithms.HmacSha512Signature
                )
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}