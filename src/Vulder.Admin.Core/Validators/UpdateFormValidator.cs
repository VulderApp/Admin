using FluentValidation;
using Vulder.Admin.Core.Models;

namespace Vulder.Admin.Core.Validators
{
    public class UpdateFormValidator : AbstractValidator<UpdateFormModel>
    {
        public UpdateFormValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull();
            RuleFor(x => x.SchoolName).NotEmpty().MinimumLength(15);
            RuleFor(x => x.SchoolUrl).NotEmpty();
            RuleFor(x => x.TimetableUrl).NotEmpty();
        }
    }
}