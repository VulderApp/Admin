using System.Data;
using FluentValidation;
using Vulder.Admin.Core.Models;

namespace Vulder.Admin.Core.Validators;

public class AuthModelValidator : AbstractValidator<AuthModel>
{
    public AuthModelValidator()
    {
        RuleFor(x => x.Email).NotNull().NotEmpty();
        RuleFor(x => x.Password).NotNull().NotEmpty().MinimumLength(8);
    }
}