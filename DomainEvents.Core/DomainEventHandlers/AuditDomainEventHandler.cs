using DomainEvents.Core.Data.Context;
using DomainEvents.Core.Data.Entities;
using DomainEvents.Core.DomainEventHandlers.Interfaces;
using DomainEvents.Core.DomainEvents;

namespace DomainEvents.Core.DomainEventHandlers
{
    public class AuditDomainEventHandler : IDomainEventHandler<AuditDomainEvent>
    {
        private readonly EfContext _efContext;

        public AuditDomainEventHandler(EfContext efContext)
        {
            _efContext = efContext;
        }

        public void Handle(AuditDomainEvent auditDomainEvent)
        {
            _efContext.AuditLog.Add(AuditLog.Create(auditDomainEvent.Description));
            _efContext.SaveChanges();
        }
    }
}