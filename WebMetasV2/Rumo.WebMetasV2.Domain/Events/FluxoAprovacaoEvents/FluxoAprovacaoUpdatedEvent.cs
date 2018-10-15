using Rumo.WebMetasV2.Domain.Core.Events;
using System;
using static Rumo.WebMetasV2.Domain.Enumeradores.Enumerador;

namespace Rumo.WebMetasV2.Domain.Events.FluxoAprovacaoEvents
{
    public class FluxoAprovacaoUpdatedEvent : Event
    {
        public FluxoAprovacaoUpdatedEvent(Guid id, Entidades entidade)
        {
            Id = id;
            Entidade = entidade;
            AggregateId = id;
        }

        public Guid Id { get; set; }
        public Entidades Entidade { get; set; }
    }
}
