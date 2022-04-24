using System.Net;
using Vulder.SharedKernel.Exceptions;

namespace Vulder.Admin.Core.Exceptions;

public class UserIsExistsException : VulderBaseException
{
    public override HttpStatusCode StatusCode => HttpStatusCode.Unauthorized;
    
    public UserIsExistsException(string message) : base(message)
    {
    }
}