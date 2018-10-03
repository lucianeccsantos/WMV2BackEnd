using System;
using System.Collections.Generic;

namespace Rumo.WebMetasV2.Application.ViewModels
{
    public class IndicadorEscopoAreaViewModel
    {
        public Guid Id { get; set; }
        public Guid IdIndicador { get; set; }
        public Guid IdEscopo { get; set; }
        public Guid IdArea { get; set; }

        public IEnumerable<IndicadorViewModel> Indicadores { get; set; }
    }
}
