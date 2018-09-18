using Rumo.WebMetasV2.Domain.Core.Events;
using System;

namespace Rumo.WebMetasV2.Domain.Events.IndicadorEscopoAreaEvents
{
    public class IndicadorEscopoAreaRemovedEvent : Event
    {
        public IndicadorEscopoAreaRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}
