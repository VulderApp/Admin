using FluentValidation.TestHelper;
using Vulder.Admin.Core.Models;
using Vulder.Admin.Core.Validators;
using Xunit;

namespace Vulder.Admin.Test.Core.Validators
{
    public class UserValidatorTest
    {
        private readonly UserValidator _validator;

        public UserValidatorTest()
        {
            _validator = new UserValidator();
        }
        
        [Fact]
        public void CheckUserValidation()
        {
            var model = new UserModel
            {
                Email = "example@example.com",
                Password = "example123!!@#"
            };
            
            Assert.True(_validator.TestValidate(model).IsValid);
        }
    }
}