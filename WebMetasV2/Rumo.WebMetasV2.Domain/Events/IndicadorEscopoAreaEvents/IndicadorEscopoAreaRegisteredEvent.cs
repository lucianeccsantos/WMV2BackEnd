using Rumo.WebMetasV2.Domain.Core.Events;
using System;

namespace Rumo.WebMetasV2.Domain.Events.IndicadorEscopoAreaEvents
{
    public class IndicadorEscopoAreaRegisteredEvent : Event
    {
        public IndicadorEscopoAreaRegisteredEvent(Guid id, Guid indicadorId, Guid escopoId, Guid areaId)
        {
            Id = id;
            IndicadorId = indicadorId;
            EscopoId = escopoId;
            AreaId = areaId;
        }

        public Guid Id { get; set; }
        public Guid IndicadorId { get; set; }
        public Guid EscopoId { get; set; }
        public Guid AreaId { get; set; }
    }
}
