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
            optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("POSTGRES_STRING") 
                                     ?? "Server=localhost;Database=admin;Uid=test;Pwd=123;");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}