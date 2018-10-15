using Rumo.WebMetasV2.Domain.Core.Commands;
using System;
using static Rumo.WebMetasV2.Domain.Enumeradores.Enumerador;

namespace Rumo.WebMetasV2.Domain.Commands.FluxoAprovacaoEtapaCommands
{
    public abstract class FluxoAprovacaoEtapaCommand : Command
    {
        public Guid Id { get; set; }
        public int Ordem { get; set; }
        public TipoEtapa TipoEtapa { get; set; }
        public Responsavel Responsavel { get; set; }
        public Guid PerfilId { get; set; }
        public bool AprovaTudo { get; set; }
        public Guid FluxoAprovacaoId { get; set; }
    }
}
