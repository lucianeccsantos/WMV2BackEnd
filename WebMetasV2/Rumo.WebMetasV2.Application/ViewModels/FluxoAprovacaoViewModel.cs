using System;
using System.Collections.Generic;
using static Rumo.WebMetasV2.Domain.Enumeradores.Enumerador;

namespace Rumo.WebMetasV2.Application.ViewModels
{
    public class FluxoAprovacaoViewModel
    {
        public Guid Id { get; set; }
        public Entidades Entidade { get; set; }

        public virtual IEnumerable<FluxoAprovacaoEtapaViewModel> Etapas { get; set; }
    }
}
