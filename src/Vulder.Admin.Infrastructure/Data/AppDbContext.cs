using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Vulder.Admin.Core.ProjectAggregate.User;

namespace Vulder.Admin.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        private readonly string _postgresConnectionString;
        public DbSet<User> Users { get; set; }
        
        public AppDbContext(string postgresConnectionString)
        {
            _postgresConnectionString = postgresConnectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(_postgresConnectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }
    }
}
