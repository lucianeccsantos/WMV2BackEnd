using Rumo.WebMetasV2.Domain.Core.Events;
using System;

namespace Rumo.WebMetasV2.Domain.Events.IndicadorEscopoAreaEvents
{
    public class IndicadorEscopoAreaUpdatedEvent : Event
    {
        public IndicadorEscopoAreaUpdatedEvent(Guid id, Guid indicadorId, Guid escopoId, Guid areaId)
        {
            Id = id;
            IndicadorId = indicadorId;
            EscopoId = escopoId;
            AreaId = areaId;
            AggregateId = id;
        }

        public Guid Id { get; set; }
        public Guid IndicadorId { get; set; }
        public Guid EscopoId { get; set; }
        public Guid AreaId { get; set; }
    }
}
