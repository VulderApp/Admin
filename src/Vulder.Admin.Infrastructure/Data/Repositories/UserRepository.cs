using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vulder.Admin.Core.ProjectAggregate.User;
using Vulder.Admin.Infrastructure.Data.Interfaces;

namespace Vulder.Admin.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbSet<User> _users;

        public UserRepository(AppDbContext context)
        {
            _users = context.Users;
        }

        public async Task<User> AddAsync(User entity)
        {
            await _users.AddAsync(entity);
            return entity;
        }

        public Task UpdateAsync(User entity)
        {
            _users.Update(entity);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(string hashedPassword)
        {
            var user = await _users.OrderBy(e => e.Email).Where(e => e.Password == hashedPassword).FirstAsync();
            _users.Remove(user);
        }
    }
}