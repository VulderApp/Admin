using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Vulder.Admin.Core.Models;
using Vulder.Admin.Core.Validators;

namespace Vulder.Admin.Infrastructure;

public static class StartupExtensions
{
    public static void AddValidators(this IServiceCollection services)
    {
        services.AddFluentValidation();

        services.AddTransient<IValidator<RegisterUserModel>, AuthModelValidator>();
        services.AddTransient<IValidator<LoginUserModel>, AuthModelValidator>();
        services.AddTransient<IValidator<ChangePasswordModel>, ChangePasswordModelValidator>();
    }
}