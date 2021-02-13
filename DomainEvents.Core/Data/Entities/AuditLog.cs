using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DomainEvents.Core.DomainEvents.Interfaces;

namespace DomainEvents.Core.Data.Entities
{
    public class AuditLog : IEntity
    {
        public int Id { get; private set; }
        public DateTime DateTime { get; private init; }
        public string Description { get; private init; }

        public static AuditLog Create(string description)
        {
            return new AuditLog
            {
                Description = description,
                DateTime = DateTime.UtcNow
            };
        }

        [NotMapped]
        public ICollection<IDomainEvent> DomainEvents { get; } = new List<IDomainEvent>();
    }
}