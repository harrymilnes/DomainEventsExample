using DomainEvents.Core.DomainEvents.Interfaces;

namespace DomainEvents.Core.DomainEventDispatcher.Interfaces
{
    public interface IDomainEventDispatcher
    {
        void Dispatch(IDomainEvent domainEvent);
    }
}