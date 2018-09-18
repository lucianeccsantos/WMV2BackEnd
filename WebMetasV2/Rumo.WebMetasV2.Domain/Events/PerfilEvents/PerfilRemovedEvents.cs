using Rumo.WebMetasV2.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rumo.WebMetasV2.Domain.Events.PerfilEvents
{
    public class PerfilRemovedEvents : Event
    {
        public PerfilRemovedEvents(Guid id)
        {
            Id = id;
            AggregateId = id;
        }
        public Guid Id { get; set; }
    }
}
