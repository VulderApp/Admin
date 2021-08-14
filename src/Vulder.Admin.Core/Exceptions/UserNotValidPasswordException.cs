using System;

namespace Vulder.Admin.Core.Exceptions
{
    public class UserNotValidPasswordException : Exception
    {
        public UserNotValidPasswordException(string message) : base(message)
        {
        }
    }
}