using System.Security.Cryptography;
using Vulder.Admin.Core.Interfaces;

namespace Vulder.Admin.Core.Services
{
    public class PasswordHashService : IPasswordHashService
    {
        public string GetHashedPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyHash(string plainPassword, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(plainPassword, hashedPassword);
        }
    }
}