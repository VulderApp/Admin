using System;
using FluentValidation.TestHelper;
using Vulder.Admin.Core.Models;
using Vulder.Admin.Core.Validators;
using Xunit;

namespace Vulder.Admin.Test.Core.Validators
{
    public class UpdateFormValidatorTest
    {
        private readonly UpdateFormValidator _validator;

        public UpdateFormValidatorTest()
        {
            _validator = new UpdateFormValidator();
        }

        [Fact]
        public void CheckUpdateFormValidator()
        {
            var model = new UpdateFormModel
            {
                Id = new Guid("4429dd64-0790-4cfb-9fec-7f7cc3672f2c"),
                SchoolName = "ZSP nr 1 w Warszawie",
                TimetableUrl = "https://google.com/form",
                SchoolUrl = "https://google.com"
            };
            
            Assert.True(_validator.TestValidate(model).IsValid);
        }
    }
}