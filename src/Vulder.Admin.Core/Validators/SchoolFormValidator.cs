using FluentValidation;
using Vulder.Admin.Core.Models;

namespace Vulder.Admin.Core.Validators
{
    public class SchoolFormValidator : AbstractValidator<SchoolFormModel>
    {
        public SchoolFormValidator()
        {
            RuleFor(x => x.SchoolName).NotEmpty().MinimumLength(15);
            RuleFor(x => x.SchoolUrl).NotEmpty();
            RuleFor(x => x.TimetableUrl).NotEmpty();
        }
    }
}