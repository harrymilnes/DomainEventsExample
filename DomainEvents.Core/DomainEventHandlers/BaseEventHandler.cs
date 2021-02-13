using DomainEvents.Core.DomainEventHandlers.Interfaces;
using DomainEvents.Core.DomainEvents.Interfaces;

namespace DomainEvents.Core.DomainEventHandlers
{
    public class BaseEventHandler<TDomainEvent> : IEventHandler where TDomainEvent : IDomainEvent
    {
        private readonly IDomainEventHandler<TDomainEvent> _domainEventHandler;

        public BaseEventHandler(IDomainEventHandler<TDomainEvent> domainEventHandler)
        {
            _domainEventHandler = domainEventHandler;
        }

        public void Handle(IDomainEvent domainEvent)
        {
            _domainEventHandler.Handle((TDomainEvent)domainEvent);
        }
    }
}