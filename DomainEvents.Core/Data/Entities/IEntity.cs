using System.Collections.Generic;
using DomainEvents.Core.DomainEvents.Abstract;

namespace DomainEvents.Core.Data.Entities
{
    public interface IEntity
    {
        ICollection<AbstractDomainEvent> DomainEvents { get; set; }
    }
}