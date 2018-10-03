using System;
using System.Collections.Generic;

namespace Rumo.WebMetasV2.Application.ViewModels
{
    public class EscopoViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public IEnumerable<IndicadorEscopoAreaViewModel> IndicadorEscopoAreas { get; set; }
        public IEnumerable<AreaViewModel> Areas { get; set; }
    }
}
