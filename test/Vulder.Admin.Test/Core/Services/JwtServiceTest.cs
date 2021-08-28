using System;
using Vulder.Admin.Core.Configuration;
using Vulder.Admin.Core.ProjectAggregate.User;
using Vulder.Admin.Core.Services;
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
                Key = "wV7unQu7Uj+2vN8ve76BZcYpPLivN4zRfHtEPJYaCuY=",
                Issuer = "https://localhost:3000"
            };

            _jwtService = new JwtService(authConfiguration);
        }

        [Fact]
        public void GenerateJwt_CheckIfIsTypeJwtModelAndEqualsWithUserDtoIdEmail()
        {
            var userDto = new UserDto
            {
                Id = Guid.NewGuid(),
                Email = "example@example.com"
            };
            
            var result = _jwtService.GetGeneratedJwtToken(userDto);
            
            Assert.NotEmpty(result);
        }
    }
}