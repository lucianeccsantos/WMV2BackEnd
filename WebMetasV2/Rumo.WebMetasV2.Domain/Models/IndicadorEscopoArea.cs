using Rumo.WebMetasV2.Domain.Core.Models;
using System;

namespace Rumo.WebMetasV2.Domain.Models
{
    public class IndicadorEscopoArea : Entity
    {
        public IndicadorEscopoArea(Guid id, Guid idIndicador, Guid idEscopo, Guid idArea)
        {
            Id = id;
            IdIndicador = idIndicador;
            IdEscopo = idEscopo;
            IdArea = idArea;
        }

        public IndicadorEscopoArea() { }

        public Guid IdIndicador { get; set; }
        public Guid IdEscopo { get; set; }
        public Guid IdArea { get; set; }

        public virtual Indicador Indicador { get; set; }
        public virtual Escopo Escopo { get; set; }
        public virtual Area Area { get; set; }
    }
}
