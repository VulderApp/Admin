using Vulder.Admin.Core.ProjectAggregate.User;

namespace Vulder.Admin.Core.Interfaces
{
    public interface IJwtService
    {
        string GetGeneratedJwtToken(UserDto userDto);
    }
}