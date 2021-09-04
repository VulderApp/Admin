using System.Text;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Vulder.Admin.Core.Models;
using Vulder.Admin.Core.Validators;

namespace Vulder.Admin.Infrastructure
{
    public static class SetupStartup
    {
        public static void AddModelsToValidate(this IServiceCollection services)
        {
            services.AddTransient<IValidator<UserModel>, UserValidator>();
            services.AddTransient<IValidator<SchoolFormModel>, SchoolFormValidator>();
        }

        public static void AddJwtDefault(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("Auth").GetValue<string>("Key"))),
                    ValidateIssuer = true,
                    ValidIssuer = configuration.GetSection("Auth").GetValue<string>("Issuer"),
                    ValidateAudience = true,
                    ValidAudience = configuration.GetSection("Auth").GetValue<string>("Audience"),
                    RequireExpirationTime = true,
                    ValidateLifetime = true
                };
            });
        }
    }
}