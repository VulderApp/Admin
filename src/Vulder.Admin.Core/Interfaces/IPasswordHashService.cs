namespace Vulder.Admin.Core.Interfaces
{
    public interface IPasswordHashService
    {
        string GetHashedPassword(string password);
        bool VerifyHash(string plainPassword, string hashedPassword);
    }
}