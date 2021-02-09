using System;
using System.Linq;
using DomainEvents.Core.DomainEventDispatcher.Interfaces;
using DomainEvents.Core.DomainEventHandlers;
using DomainEvents.Core.DomainEventHandlers.Abstract;
using DomainEvents.Core.DomainEventHandlers.Interfaces;
using DomainEvents.Core.DomainEvents.Abstract;
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

        public void Dispatch(AbstractDomainEvent abstractDomainEvent)
        {
            var handlerType = typeof(IDomainEventHandler<>).MakeGenericType(abstractDomainEvent.GetType());
            var genericWrapperType = typeof(BaseDomainEventHandler<>).MakeGenericType(abstractDomainEvent.GetType());
            var eventHandlerServices = _serviceProvider.GetServices(handlerType);

            if (!eventHandlerServices.Any())
                throw new Exception($"No event handlers registered for this domain event!");
            
            var eventHandlers = eventHandlerServices
                .Select(handler => (AbstractDomainEventHandler)Activator.CreateInstance(genericWrapperType, handler))
                .ToList();

            eventHandlers.ForEach(it => it.Handle(abstractDomainEvent));
        }
    }
}