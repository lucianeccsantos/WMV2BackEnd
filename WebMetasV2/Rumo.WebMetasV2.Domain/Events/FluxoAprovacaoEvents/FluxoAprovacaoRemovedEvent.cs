using Rumo.WebMetasV2.Domain.Core.Events;
using System;

namespace Rumo.WebMetasV2.Domain.Events.FluxoAprovacaoEvents
{
    public class FluxoAprovacaoRemovedEvent : Event
    {
        public FluxoAprovacaoRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public Guid Id { get; set; }
    }
}
