using DomainEvents.Core.DomainEvents.Interfaces;

namespace DomainEvents.Core.DomainEventHandlers.Interfaces
{
    public interface IDomainEventHandler<in TDomainEvent> where TDomainEvent : IDomainEvent
    {
        void Handle(TDomainEvent auditDomainEvent);
    }
}