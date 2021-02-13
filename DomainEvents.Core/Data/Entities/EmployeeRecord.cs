using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DomainEvents.Core.DomainEvents;
using DomainEvents.Core.DomainEvents.Interfaces;

namespace DomainEvents.Core.Data.Entities
{
    public class EmployeeRecord : IEntity
    {
        public int Id { get; private set; }
        public string Description { get; private set; }
        public bool IsDeleted { get; private set; }

        public static EmployeeRecord Create(
            string description)
        {
            return new EmployeeRecord
            {
                Description = description,
                IsDeleted = false
            };
        }
        
        public void Update(string description)
        {
            DomainEvents.Add(AuditDomainEvent.Create("Updated"));
            Description = description;
        }

        public void Delete()
        {
            DomainEvents.Add(AuditDomainEvent.Create("Deleted"));
            IsDeleted = true;
        }

        [NotMapped]
        public ICollection<IDomainEvent> DomainEvents { get; } = new List<IDomainEvent>();
    }
}