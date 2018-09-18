using Rumo.WebMetasV2.Domain.Core.Events;
using System;

namespace Rumo.WebMetasV2.Domain.Events.IndicadorEscopoAreaEvents
{
    public class IndicadorEscopoAreaUpdatedEvent : Event
    {
        public IndicadorEscopoAreaUpdatedEvent(Guid id, Guid idIndicador, Guid idEscopo, Guid idArea)
        {
            Id = id;
            IdIndicador = idIndicador;
            IdEscopo = idEscopo;
            IdArea = idArea;
            AggregateId = id;
        }

        public Guid Id { get; set; }
        public Guid IdIndicador { get; set; }
        public Guid IdEscopo { get; set; }
        public Guid IdArea { get; set; }
    }
}
