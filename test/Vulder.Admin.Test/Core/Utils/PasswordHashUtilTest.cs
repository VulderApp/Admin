using Vulder.Admin.Core.Utils;
using Xunit;

namespace Vulder.Admin.Test.Core.Utils
{
    public class PasswordHashUtilTest
    {
        private const string PlainPassword = "qwerty123";
        
        [Fact]
        public void GeneratePasswordHash_ValidateHashedPassword()
        {
            var hashedPassword = PasswordHashUtil.GetHashedPassword(PlainPassword);
            Assert.True(PasswordHashUtil.VerifyHash(PlainPassword, hashedPassword));
        }
    }
}