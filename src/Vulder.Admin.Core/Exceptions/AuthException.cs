namespace Vulder.Admin.Core.Exceptions;

public class AuthException : Exception
{
    public AuthException(string message) : base(message)
    {
    }
}