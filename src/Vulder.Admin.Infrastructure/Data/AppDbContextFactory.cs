using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Vulder.Admin.Infrastructure.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("POSTGRES_STRING") ?? "postgresql://test:123@localhost:5432/admin");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}