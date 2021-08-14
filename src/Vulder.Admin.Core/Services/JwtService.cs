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

        public string GenerateToken(UserDto user)
        {
            var credentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Auth:Key"])),
                SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                _configuration["Auth:Issuer"],
                _configuration["Auth:Audience"],
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