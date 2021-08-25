using System;
using Vulder.Admin.Core.Models;
using Vulder.Admin.Core.ProjectAggregate.User;
using Vulder.Admin.Core.Services;
using Vulder.Admin.Infrastructure.Configuration;
using Xunit;

namespace Vulder.Admin.Test.Core.Services
{
    public class JwtServiceTest
    {
        private readonly JwtGenerationService _jwtService;

        public JwtServiceTest()
        {
            var authConfiguration = new AuthConfiguration
            {
                Key = "wV7unQu7Uj+2vN8ve76BZcYpPLivN4zRfHtEPJYaCuY="
            };

            _jwtService = new JwtGenerationService(authConfiguration);
        }

        [Fact]
        public void GenerateJwt_CheckIfIsTypeJwtModelAndEqualsWithUserDtoIdEmail()
        {
            var userDto = new UserDto
            {
                Id = Guid.NewGuid(),
                Email = "example@example.com"
            };
            
            var jwtToken = _jwtService.GetGeneratedJwtToken(userDto);
            var result = _jwtService.GetUserDataFromJwtToken(jwtToken);
            
            Assert.IsType<JwtModel>(result);
            Assert.Equal(userDto.Id.ToString(), result.Id);
            Assert.Equal(userDto.Email, result.Email);
        }
    }
}