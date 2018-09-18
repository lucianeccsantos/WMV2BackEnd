using Rumo.WebMetasV2.Domain.Core.Events;
using System;

namespace Rumo.WebMetasV2.Domain.Events.IndicadorEscopoAreaEvents
{
    public class IndicadorEscopoAreaRegisteredEvent : Event
    {
        public IndicadorEscopoAreaRegisteredEvent(Guid id, Guid idIndicador, Guid idEscopo, Guid idArea)
        {
            Id = id;
            IdIndicador = idIndicador;
            IdEscopo = idEscopo;
            IdArea = idArea;
        }

        public Guid Id { get; set; }
        public Guid IdIndicador { get; set; }
        public Guid IdEscopo { get; set; }
        public Guid IdArea { get; set; }
    }
}
