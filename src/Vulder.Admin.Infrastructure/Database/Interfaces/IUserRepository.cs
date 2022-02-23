using Vulder.Admin.Core.ProjectAggregate.User;

namespace Vulder.Admin.Infrastructure.Database.Interfaces;

public interface IUserRepository
{
    Task<User> CreateUser(User user);
    Task<int> GetUserCount();
    Task<User?> GetUser(string email);
    Task UpdateUser(User user);
}