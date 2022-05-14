using FluentValidation;
using Vulder.Admin.Core.Models;

namespace Vulder.Admin.Core.Validators;

public class ChangePasswordModelValidator : AbstractValidator<ChangePasswordModel>
{
    public ChangePasswordModelValidator()
    {
        const int passwordLenght = 6;

        RuleFor(x => x.CurrentPassword)
            .NotNull()
            .NotEmpty()
            .MinimumLength(passwordLenght)
            .NotEqual(x => x.NewPassword);

        RuleFor(x => x.NewPassword)
            .NotNull()
            .NotEmpty()
            .MinimumLength(passwordLenght)
            .NotEqual(x => x.CurrentPassword);
    }
}