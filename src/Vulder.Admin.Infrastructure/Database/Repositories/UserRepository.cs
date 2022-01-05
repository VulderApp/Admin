using Microsoft.EntityFrameworkCore;
using Vulder.Admin.Core.ProjectAggregate.User;
using Vulder.Admin.Infrastructure.Database.Interfaces;

namespace Vulder.Admin.Infrastructure.Database.Repositories;

public class UserRepository : IUserRepository
{
    private DbSet<User>? Users { get; }

    public UserRepository(AppDbContext context)
    {
        Users = context.Users;
    }

    public async Task<User> CreateUser(User user)
    {
        await Users!.AddAsync(user);

        return user;
    }
}