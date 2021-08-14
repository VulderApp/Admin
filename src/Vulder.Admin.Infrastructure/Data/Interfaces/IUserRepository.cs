using System.Threading.Tasks;
using Vulder.Admin.Core.ProjectAggregate.User;

namespace Vulder.Admin.Infrastructure.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmail(string email);
        Task<User> AddAsync(User entity);
        Task UpdateAsync(User entity);
        Task DeleteAsync(string hashedPassword);
    }
}