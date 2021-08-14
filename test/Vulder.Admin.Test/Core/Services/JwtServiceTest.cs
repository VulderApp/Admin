using System;
using Vulder.Admin.Core.ProjectAggregate.User;
using Vulder.Admin.Core.Services;
using Vulder.Admin.Infrastructure.Configurations;
using Xunit;

namespace Vulder.Admin.Test.Core.Services
{
    public class JwtServiceTest
    {
        private readonly JwtService _jwtService;

        public JwtServiceTest()
        {
            var authConfiguration = new AuthConfiguration
            {
                Issuer = "https://localhost:5001",
                Audience = "https://localhost:5001",
                Key = "wV7unQu7Uj+2vN8ve76BZcYpPLivN4zRfHtEPJYaCuY="
            };

            _jwtService = new JwtService(authConfiguration);
        }

        [Fact]
        public void GenerateJwt_CheckIfNotEmptyAndIsTypeString()
        {
            var result = _jwtService.GetGeneratedToken(new UserDto
            {
                Id = Guid.NewGuid(),
                Email = "example@example.com"
            });
            
            Assert.IsType<string>(result);
            Assert.NotEmpty(result);
        }
    }
}