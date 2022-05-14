using System.Net;
using Vulder.SharedKernel.Exceptions;

namespace Vulder.Admin.Core.Exceptions;

public class UserIsExistsException : VulderBaseException
{
    public UserIsExistsException(string message) : base(message)
    {
    }

    public override HttpStatusCode StatusCode => HttpStatusCode.Unauthorized;
}