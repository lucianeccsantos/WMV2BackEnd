using Rumo.WebMetasV2.Domain.Core.Commands;
using System;

namespace Rumo.WebMetasV2.Domain.Commands.IndicadorEscopoAreaCommands
{
    public abstract class IndicadorEscopoAreaCommand : Command
    {
        public Guid Id { get; set; }
        public Guid IdIndicador { get; set; }
        public Guid IdEscopo { get; set; }
        public Guid IdArea { get; set; }
    }
}
