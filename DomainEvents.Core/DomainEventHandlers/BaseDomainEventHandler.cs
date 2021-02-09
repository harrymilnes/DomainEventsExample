using DomainEvents.Core.DomainEventHandlers.Abstract;
using DomainEvents.Core.DomainEventHandlers.Interfaces;
using DomainEvents.Core.DomainEvents.Abstract;

namespace DomainEvents.Core.DomainEventHandlers
{
    public class BaseDomainEventHandler<TDomainEvent> : AbstractDomainEventHandler where TDomainEvent : AbstractDomainEvent
    {
        private readonly IDomainEventHandler<TDomainEvent> _domainEventHandler;

        public BaseDomainEventHandler(IDomainEventHandler<TDomainEvent> domainEventHandler)
        {
            _domainEventHandler = domainEventHandler;
        }

        public override void Handle(AbstractDomainEvent abstractDomainEvent)
        {
            _domainEventHandler.Handle((TDomainEvent)abstractDomainEvent);
        }
    }
}