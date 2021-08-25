using System;
using JWT.Algorithms;
using JWT.Builder;
using Microsoft.Extensions.Configuration;
using Vulder.Admin.Core.Interfaces;
using Vulder.Admin.Core.ProjectAggregate.User;

namespace Vulder.Admin.Core.Services
{
    public class JwtGenerationService : IJwtService
    {
        private readonly IAuthConfiguration _configuration;
        
        public JwtGenerationService(IAuthConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetGeneratedJwtToken(UserDto userDto)
            => JwtBuilder.Create()
                .WithAlgorithm(new HMACSHA512Algorithm())
                .WithSecret(_configuration.Key)
                .AddClaim(ClaimName.JwtId, userDto.Id)
                .AddClaim(ClaimName.Address, userDto.Email)
                .AddClaim(ClaimName.ExpirationTime, DateTimeOffset.UtcNow.AddHours(1).ToUnixTimeSeconds())
                .Encode();

        public string GetUserDataFromJwtToken(string token)
            => JwtBuilder.Create()
                .WithAlgorithm(new HMACSHA512Algorithm())
                .WithSecret(_configuration.Key)
                .MustVerifySignature()
                .Decode(token);
    }
}