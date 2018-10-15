using System;
using static Rumo.WebMetasV2.Domain.Enumeradores.Enumerador;

namespace Rumo.WebMetasV2.Application.ViewModels
{
    public class FluxoAprovacaoEtapaViewModel
    {
        public int Ordem { get; private set; }
        public TipoEtapa TipoEtapa { get; private set; }
        public Responsavel Responsavel { get; private set; }
        public Guid PerfilId { get; private set; }
        public bool AprovaTudo { get; private set; }
        public Guid FluxoAprovacaoId { get; private set; }

        public virtual PerfilViewModel Perfil { get; set; }
        public virtual FluxoAprovacaoViewModel FluxoAprovacao { get; set; }
    }
}
