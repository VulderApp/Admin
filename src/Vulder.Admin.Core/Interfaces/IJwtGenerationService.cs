using Vulder.Admin.Core.ProjectAggregate.User;

namespace Vulder.Admin.Core.Interfaces
{
    public interface IJwtGenerationService
    {
        string GetGeneratedJwtToken(UserDto userDto);
    }
}