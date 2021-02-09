using DomainEvents.Core.DomainEvents.Abstract;

namespace DomainEvents.Core.DomainEventHandlers.Interfaces
{
    public interface IDomainEventHandler<in TDomainEvent> where TDomainEvent : AbstractDomainEvent
    {
        void Handle(TDomainEvent auditDomainEvent);
    }
}