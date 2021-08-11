using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vulder.Admin.Core.ProjectAggregate.User;
using Vulder.Admin.Infrastructure.Data.Interfaces;

namespace Vulder.Admin.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> AddAsync(User entity)
        {
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(User entity)
        {
            _context.Users.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string hashedPassword)
        {
            var user = await _context.Users.OrderBy(e => e.Email).Where(e => e.Password == hashedPassword).FirstAsync();
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}