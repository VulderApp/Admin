using System.Text;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Vulder.Admin.Core.Models;
using Vulder.Admin.Core.Validators;

namespace Vulder.Admin.Infrastructure;

public static class StartupExtensions
{
    public static void AddValidators(this IServiceCollection services)
    {
        services.AddFluentValidation();

        services.AddTransient<IValidator<RegisterUserModel>, AuthModelValidator>();
    }
    
    public static void AddDefaultJwtConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        var authSection = configuration.GetSection("Jwt");
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey =
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authSection.GetValue<string>("Key"))),
                    ValidateIssuer = true,
                    ValidIssuer = authSection.GetValue<string>("Issuer"),
                    ValidateAudience = true,
                    ValidAudience = authSection.GetValue<string>("Audience"),
                    RequireExpirationTime = true,
                    ValidateLifetime = true
                };
            });
    }
}