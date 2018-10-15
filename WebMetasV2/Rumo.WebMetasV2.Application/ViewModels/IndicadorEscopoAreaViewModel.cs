using System;
using System.Collections.Generic;

namespace Rumo.WebMetasV2.Application.ViewModels
{
    public class IndicadorEscopoAreaViewModel
    {
        public Guid Id { get; set; }
        public Guid IndicadorId { get; set; }
        public Guid EscopoId { get; set; }
        public Guid AreaId { get; set; }

        public IEnumerable<IndicadorViewModel> Indicadores { get; set; }
    }
}
