using Vulder.Admin.Core.Models;
using Vulder.Admin.Core.ProjectAggregate.User;

namespace Vulder.Admin.Core.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(UserDto user);
    }
}