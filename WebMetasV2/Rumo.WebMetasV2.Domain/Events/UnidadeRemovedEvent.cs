using Rumo.WebMetasV2.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rumo.WebMetasV2.Domain.Events
{
    public class UnidadeRemovedEvent : Event
    {
        public UnidadeRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }
        public Guid Id { get; set; }
    }
}
