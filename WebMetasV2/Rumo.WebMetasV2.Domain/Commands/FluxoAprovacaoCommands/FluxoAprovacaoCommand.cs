using Rumo.WebMetasV2.Domain.Core.Commands;
using System;
using static Rumo.WebMetasV2.Domain.Enumeradores.Enumerador;

namespace Rumo.WebMetasV2.Domain.Commands.FluxoAprovacaoCommands
{
    public abstract class FluxoAprovacaoCommand : Command
    {
        public Guid Id { get; set; }
        public Entidades Entidade { get; set; }
    }
}
