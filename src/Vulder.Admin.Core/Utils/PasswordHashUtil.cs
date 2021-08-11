namespace Vulder.Admin.Core.Utils
{
    public static class PasswordHashUtil
    {
        public static string GetHashedPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public static bool VerifyHash(string plainPassword, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(plainPassword, hashedPassword);
        }
    }
}