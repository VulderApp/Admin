using FluentValidation.TestHelper;
using Vulder.Admin.Core.Models;
using Vulder.Admin.Core.Validators;
using Xunit;

namespace Vulder.Admin.Test.Core.Validators
{
    public class SchoolFormValidatorTest
    {
        private readonly SchoolFormValidator _validator;

        public SchoolFormValidatorTest()
        {
            _validator = new SchoolFormValidator();
        }

        [Fact]
        public void CheckSchoolFormValidator()
        {
            var model = new SchoolFormModel
            {
                SchoolName = "ZSP nr 2 w Warszawie",
                TimetableUrl = "https://google.com/form",
                SchoolUrl = "https://google.com"
            };
            
            Assert.True(_validator.TestValidate(model).IsValid);
        }
    }
}