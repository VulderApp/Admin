using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Vulder.Admin.Core.Interfaces;
using Vulder.Admin.Core.ProjectAggregate.User;

namespace Vulder.Admin.Core.Services
{
    public class JwtService : IJwtService
    {
        private readonly IAuthConfiguration _configuration;
        
        public JwtService(IAuthConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetGeneratedToken(UserDto user)
        {
            var credentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.Key)),
                SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                _configuration.Issuer,
                _configuration.Audience,
                new []
                {
                    new Claim(ClaimTypes.Email, user.Email)
                },
                DateTime.Now,
                DateTime.Now.AddDays(1),
                credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}