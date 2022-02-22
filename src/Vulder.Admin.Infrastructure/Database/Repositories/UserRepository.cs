using Microsoft.EntityFrameworkCore;
using Vulder.Admin.Core.ProjectAggregate.User;
using Vulder.Admin.Infrastructure.Database.Interfaces;

namespace Vulder.Admin.Infrastructure.Database.Repositories;

public class UserRepository : IUserRepository
{
    public UserRepository(AppDbContext context)
    {
        Users = context.Users;
    }

    private DbSet<User>? Users { get; }

    public async Task<User> CreateUser(User user)
    {
        await Users!.AddAsync(user);

        return user;
    }

    public async Task<int> GetUserCount()
    {
        return await Users!.CountAsync();
    }

    public async Task<User?> GetUser(string email)
    {
        return await Users!.Where(e => e.Email == email).FirstOrDefaultAsync();
    }

    public Task UpdateUser(User user)
    {
        Users!.Update(user);
        return Task.CompletedTask;
    }
}