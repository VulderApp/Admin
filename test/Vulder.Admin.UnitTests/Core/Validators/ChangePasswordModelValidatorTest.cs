using FluentValidation.TestHelper;
using Vulder.Admin.Core.Models;
using Vulder.Admin.Core.Validators;
using Xunit;

namespace Vulder.Admin.UnitTests.Core.Validators;

public class ChangePasswordModelValidatorTest
{

    [Fact]
    public void ValidateChangePasswordModel_Correct()
    {
        var model = new ChangePasswordModel
        {
            CurrentPassword = "XSfsT1bvbPHLwCcaPYq/Waum5I8EUSZ1aTLy1bo/Gz0=",
            NewPassword = "NzjDED/7tqsSFI62KRwHyBe8eHOFjGbyiDw/M1BEOEw="
        };

        var result = new ChangePasswordModelValidator().TestValidate(model).IsValid;

        Assert.True(result);
    }

    [Fact]
    public void ValidateChangePasswordModel_NotValid()
    {
        var model = new ChangePasswordModel
        {
            CurrentPassword = "example",
            NewPassword = "example"
        };

        var result = new ChangePasswordModelValidator().TestValidate(model).IsValid;

        Assert.False(result);
    }
}