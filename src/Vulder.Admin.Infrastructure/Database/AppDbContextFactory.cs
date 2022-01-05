using Microsoft.EntityFrameworkCore.Design;

namespace Vulder.Admin.Infrastructure.Database;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        return new AppDbContext(
            Environment.GetEnvironmentVariable("POSTGRES_CONNECTION_STRING") ??
            throw new Exception("Environment POSTGRES_CONNECTION_STRING is empty")
            );
    }
}