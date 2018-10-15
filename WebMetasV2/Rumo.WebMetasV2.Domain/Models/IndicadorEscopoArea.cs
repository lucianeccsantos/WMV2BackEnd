using Rumo.WebMetasV2.Domain.Core.Models;
using System;

namespace Rumo.WebMetasV2.Domain.Models
{
    public class IndicadorEscopoArea : Entity
    {
        public IndicadorEscopoArea(Guid id, Guid indicadorId, Guid escopoId, Guid areaId)
        {
            Id = id;
            IndicadorId = indicadorId;
            EscopoId = escopoId;
            AreaId = areaId;
        }

        public IndicadorEscopoArea() { }

        public Guid IndicadorId { get; set; }
        public Guid EscopoId { get; set; }
        public Guid AreaId { get; set; }

        public virtual Indicador Indicador { get; set; }
        public virtual Escopo Escopo { get; set; }
        public virtual Area Area { get; set; }
    }
}
