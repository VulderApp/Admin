using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Vulder.Admin.Infrastructure.Configuration;
using Vulder.SharedKernel;

namespace Vulder.Admin.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        private readonly IMediator _mediator;

        public AppDbContext(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            if (_mediator == null) return result;

            var entitiesWithEvents = ChangeTracker.Entries<BaseEntity>()
                .Select(e => e.Entity)
                .Where(e => e.Events.Any())
                .ToArray();

            foreach (var entity in entitiesWithEvents)
            {
                var events = entity.Events.ToArray();
                entity.Events.Clear();
                foreach (var domainEvent in events)
                {
                    await _mediator.Publish(domainEvent, cancellationToken).ConfigureAwait(false);
                }
            }

            return result;
        }

        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }
    }
}
