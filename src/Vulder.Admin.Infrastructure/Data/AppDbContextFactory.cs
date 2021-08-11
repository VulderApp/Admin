using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Vulder.Admin.Infrastructure.Data
{
    public sealed class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            return new AppDbContext(Environment.GetEnvironmentVariable("POSTGRES_STRING") 
                                    ?? "Server=localhost;Database=admin;Uid=test;Pwd=123;");
        }
    }
}