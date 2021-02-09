using DomainEvents.Core.DomainEvents.Abstract;

namespace DomainEvents.Core.DomainEventDispatcher.Interfaces
{
    public interface IDomainEventDispatcher
    {
        void Dispatch(AbstractDomainEvent abstractDomainEvent);
    }
}