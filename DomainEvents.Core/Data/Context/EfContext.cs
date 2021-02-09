using System.Linq;
using DomainEvents.Core.Data.Entities;
using DomainEvents.Core.DomainEventDispatcher.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DomainEvents.Core.Data.Context
{
    public class EfContext : DbContext
    {
        private readonly IDomainEventDispatcher _domainEventDispatcher;
        
        public EfContext(IDomainEventDispatcher domainEventDispatcher)
        {
            _domainEventDispatcher = domainEventDispatcher;
        }
        
        public EfContext(DbContextOptions<EfContext> options, IDomainEventDispatcher domainEventDispatcher) : base(options)
        {
            _domainEventDispatcher = domainEventDispatcher;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;database=DomainEventsExample;trusted_connection=yes;");
        }

        public DbSet<EmployeeRecord> EmployeeRecord { get; set; }
        public DbSet<AuditLog> AuditLog { get; set; }
        
        public override int SaveChanges() {
            var domainEventEntities = ChangeTracker.Entries<IEntity>()
                .Select(po => po.Entity)
                .Where(po => po.DomainEvents.Any())
                .ToArray();

            foreach (var entity in domainEventEntities)
            {
                var events = entity.DomainEvents.ToArray();
                entity.DomainEvents.Clear();
                foreach (var domainEvent in events)
                {
                    _domainEventDispatcher.Dispatch(domainEvent);
                }
            }

            return base.SaveChanges();
        }
    }
}