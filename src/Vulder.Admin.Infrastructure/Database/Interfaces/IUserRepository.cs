using Vulder.Admin.Core.ProjectAggregate.User;

namespace Vulder.Admin.Infrastructure.Database.Interfaces;

public interface IUserRepository
{
    Task<User> CreateUser(User user);
    Task<User?> GetUser(string email);
}