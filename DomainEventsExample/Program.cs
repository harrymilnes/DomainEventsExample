using System;
using DomainEvents.Core.Data.Context;
using DomainEvents.Core.Data.Repository;
using DomainEvents.Core.DomainEventDispatcher;
using DomainEvents.Core.DomainEventDispatcher.Interfaces;
using DomainEvents.Core.DomainEventHandlers;
using DomainEvents.Core.DomainEventHandlers.Interfaces;
using DomainEvents.Core.DomainEvents;
using Microsoft.Extensions.DependencyInjection;

namespace DomainEventsExample
{
    internal static class Program
    {
        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
                
            services.AddSingleton<IEmployeeRecordRepository, EmployeeRecordRepository>();
            services.AddSingleton<Application>();
            services.AddSingleton<IDomainEventDispatcher, DomainEventDispatcher>();
            services.AddSingleton<IDomainEventHandler<AuditDomainEvent>, AuditDomainEventHandler>();
            services.AddDbContext<EfContext>();

            return services;
        }
        
        private static void Main()
        {
            var services = ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();
            
            var application = serviceProvider.GetService<Application>();
            if (application == null)
                throw new Exception("Well, shit.");
            
            application.Run();
            Console.ReadLine();
        }
    }
}