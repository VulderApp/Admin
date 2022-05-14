using Vulder.Admin.Core.Utils;
using Xunit;

namespace Vulder.Admin.UnitTests.Core.Utils;

public class PasswordUtilTest
{
    private const string PlainPassword = "example123";

    [Fact]
    public void TestPasswordHashing_ChecksDecryptedPasswordIsCorrectWithPlainPassword()
    {
        Assert.True(PasswordUtil.VerifyPassword(
            PlainPassword,
            PasswordUtil.GetEncryptedPassword(PlainPassword))
        );
    }
}