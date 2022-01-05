namespace Vulder.Admin.Core.Utils;

public class PasswordUtil
{
    public static string GetEncryptedPassword(string password)
    {
        return BCrypt.Net.BCrypt.EnhancedHashPassword(password);
    }

    public static bool VerifyPassword(string plainPassword, string hashedPassword)
    {
        return BCrypt.Net.BCrypt.EnhancedVerify(plainPassword, hashedPassword);
    }
}