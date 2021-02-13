using System.Collections.Generic;
using DomainEvents.Core.DomainEvents.Interfaces;

namespace DomainEvents.Core.Data.Entities
{
    public interface IEntity
    {
        public int Id { get; }
        ICollection<IDomainEvent> DomainEvents { get; }
    }
}