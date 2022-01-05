using FluentValidation.TestHelper;
using Vulder.Admin.Core.Models;
using Vulder.Admin.Core.Validators;
using Xunit;

namespace Vulder.Admin.UnitTests.Core.Validators;

public class AuthModelValidatorTest
{
    [Fact]
    public void ValidateAuthModel_Correct()
    {
        var model = new AuthModel
        {
            Email = "example@example.com",
            Password = "example123example123"
        };
        
        var result = new AuthModelValidator().TestValidate(model).IsValid;
        
        Assert.True(result);
    }
    
    [Fact]
    public void ValidateAuthModel_NotValid()
    {
        var model = new AuthModel
        {
            Email = "exampl",
            Password = null
        };
        
        var result = new AuthModelValidator().TestValidate(model).IsValid;
        
        Assert.False(result);
    }
}