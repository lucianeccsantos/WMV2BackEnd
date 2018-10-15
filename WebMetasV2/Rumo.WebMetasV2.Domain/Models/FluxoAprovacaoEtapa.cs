using Rumo.WebMetasV2.Domain.Core.Models;
using System;
using static Rumo.WebMetasV2.Domain.Enumeradores.Enumerador;

namespace Rumo.WebMetasV2.Domain.Models
{
    public class FluxoAprovacaoEtapa : Entity
    {
        public FluxoAprovacaoEtapa(Guid id, int ordem, TipoEtapa tipoEtapa, Responsavel responsavel, Guid perfilId, bool aprovaTudo)
        {
            Id = id;
            Ordem = ordem;
            TipoEtapa = tipoEtapa;
            Responsavel = responsavel;
            PerfilId = perfilId;
            AprovaTudo = aprovaTudo;
        }

        public int Ordem { get; private set; }
        public TipoEtapa TipoEtapa { get; private set; }
        public Responsavel Responsavel { get; private set; }
        public Guid PerfilId { get; private set; }
        public bool AprovaTudo { get; private set; }
        public Guid FluxoAprovacaoId { get; private set; }

        public virtual Perfil Perfil { get; set; }
        public virtual FluxoAprovacao FluxoAprovacao { get; set; }
    }
}
