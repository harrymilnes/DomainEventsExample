using System;
using System.Linq;
using DomainEvents.Core.DomainEventDispatcher.Interfaces;
using DomainEvents.Core.DomainEventHandlers;
using DomainEvents.Core.DomainEventHandlers.Interfaces;
using DomainEvents.Core.DomainEvents.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DomainEvents.Core.DomainEventDispatcher
{
    public class DomainEventDispatcher : IDomainEventDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public DomainEventDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void Dispatch(IDomainEvent domainEvent)
        {
            var domainEventHandlerInterfaceType = typeof(IDomainEventHandler<>).MakeGenericType(domainEvent.GetType());
            var genericBaseType = typeof(BaseEventHandler<>).MakeGenericType(domainEvent.GetType());
            var domainEventHandlers = _serviceProvider.GetServices(domainEventHandlerInterfaceType)
                .ToList();

            if (!domainEventHandlers.Any())
                throw new Exception($"No event handlers registered for this domain event!");
            
            var eventHandlers = domainEventHandlers
                .Select(handler => (IEventHandler)Activator.CreateInstance(genericBaseType, handler))
                .ToList();

            eventHandlers.ForEach(it => it.Handle(domainEvent));
        }
    }
}