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
        private readonly IMediator _mediator;
        private readonly string _postgresConnection;
        public DbSet<User> Users { get; set; }
        public DbSet<School> Schools { get; set; }

        public AppDbContext(IMediator mediator, string connectionString)
        {
            _mediator = mediator;
            _postgresConnection = connectionString;
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_postgresConnection,
                b => b.MigrationsAssembly("Vulder.Admin.Infrastructure"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
            => await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }
    }
}
