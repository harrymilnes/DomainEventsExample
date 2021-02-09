using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DomainEvents.Core.DomainEvents.Abstract;

namespace DomainEvents.Core.Data.Entities
{
    public class AuditLog : IEntity
    {
        public int Id { get; private set; }
        public DateTime DateTime { get; private set; }
        public string Description { get; private set; }

        public static AuditLog Create(string description)
        {
            return new AuditLog
            {
                Description = description,
                DateTime = DateTime.UtcNow
            };
        }

        [NotMapped]
        public ICollection<AbstractDomainEvent> DomainEvents { get; set; }
    }
}