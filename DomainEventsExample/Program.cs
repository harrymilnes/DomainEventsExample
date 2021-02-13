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
            
            services.AddSingleton<Application>();
            services.AddTransient<IEmployeeRecordRepository, EmployeeRecordRepository>();
            services.AddTransient<IDomainEventDispatcher, DomainEventDispatcher>();
            services.AddTransient<IDomainEventHandler<AuditDomainEvent>, AuditDomainEventHandler>();
            services.AddDbContext<EfContext>();

            return services;
        }
        
        private static void Main()
        {
            var services = ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();
            
            var applicationService = serviceProvider.GetService<Application>();
            if (applicationService == null)
                throw new Exception($"{nameof(applicationService)} Not found!");
            
            applicationService.Run();
            Console.ReadLine();
        }
    }
}