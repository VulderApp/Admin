using Vulder.Admin.Core.ProjectAggregate.User;

namespace Vulder.Admin.Application.Auth.Jwt;

public interface IJwtGenerationService
{
    string GetGeneratedJwtToken(User userDto);
}