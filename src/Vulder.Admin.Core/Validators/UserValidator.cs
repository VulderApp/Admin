using FluentValidation;
using Vulder.Admin.Core.Models;

namespace Vulder.Admin.Core.Validators
{
    public class UserValidator : AbstractValidator<UserModel>
    {
        public UserValidator()
        {
            RuleFor(x => x.Email).NotEmpty().MinimumLength(8).EmailAddress();
            RuleFor(x => x.Password).NotEmpty().MinimumLength(8);
        }
    }
}