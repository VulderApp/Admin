using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vulder.Admin.Core.ProjectAggregate.School;
using Vulder.Admin.Core.ProjectAggregate.User;

namespace Vulder.Admin.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        private readonly string _postgresConnectionString;
        public DbSet<User> Users { get; set; }
        public DbSet<School> Schools { get; set; }
        
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
