using DomainEvents.Core.DomainEvents.Abstract;

namespace DomainEvents.Core.DomainEvents
{
    public class AuditDomainEvent : AbstractDomainEvent
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