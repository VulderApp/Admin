using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Vulder.Admin.Core.Models;
using Vulder.Admin.Core.Validators;

namespace Vulder.Admin.Infrastructure
{
    public static class SetupStartup
    {
        public static void AddModelsToValidate(this IServiceCollection services)
        {
            services.AddTransient<IValidator<UserModel>, UserValidator>();
        }
    }
}