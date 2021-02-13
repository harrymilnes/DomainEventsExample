using DomainEvents.Core.DomainEvents.Interfaces;

namespace DomainEvents.Core.DomainEventHandlers.Interfaces
{
    public interface IEventHandler
    {
        void Handle(IDomainEvent domainEvent);
    }
}