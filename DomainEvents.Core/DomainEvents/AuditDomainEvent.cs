using DomainEvents.Core.DomainEvents.Interfaces;

namespace DomainEvents.Core.DomainEvents
{
    public class AuditDomainEvent : IDomainEvent
    {
        public string Description { get; private set; }

        public static AuditDomainEvent Create(string description)
        {
            return new AuditDomainEvent
            {
                Description = description
            };
        }
    }
}