using Rumo.WebMetasV2.Domain.Core.Commands;
using System;

namespace Rumo.WebMetasV2.Domain.Commands.IndicadorEscopoAreaCommands
{
    public abstract class IndicadorEscopoAreaCommand : Command
    {
        public Guid Id { get; set; }
        public Guid IndicadorId { get; set; }
        public Guid EscopoId { get; set; }
        public Guid AreaId { get; set; }
    }
}
