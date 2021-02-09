using DomainEvents.Core.DomainEvents.Abstract;

namespace DomainEvents.Core.DomainEventHandlers.Abstract
{
    public abstract class AbstractDomainEventHandler
    {
        public abstract void Handle(AbstractDomainEvent abstractDomainEvent);
    }
}