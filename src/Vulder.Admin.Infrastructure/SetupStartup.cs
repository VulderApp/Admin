using System;
using System.Linq;
using System.Security.Claims;
using Autofac.Core;
using JWT;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Vulder.Admin.Core.Interfaces;
using Vulder.Admin.Infrastructure.Configuration;

namespace Vulder.Admin.Infrastructure
{
    public static class SetupStartup
    {
        public static void AddDefaultJwt(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtAuthenticationDefaults.AuthenticationScheme;
            }).AddJwt(options =>
            {
                options.Keys = new[] { configuration.GetSection("Auth")["Key"] };
                options.VerifySignature = true;
                options.TicketFactory = (identify, scheme) => new AuthenticationTicket(
                    new ClaimsPrincipal(identify),
                    new AuthenticationProperties(),
                        scheme.Name
                    );
                options.IdentityFactory = dic => new ClaimsIdentity(
                    dic.Select(p => new Claim(p.Key, p.Value))
                    );
            });
        }
    }
}