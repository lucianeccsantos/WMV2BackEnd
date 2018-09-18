using Rumo.WebMetasV2.Domain.Core.Commands;
using System;

namespace Rumo.WebMetasV2.Domain.Commands.AreaCommands
{
    public abstract class AreaCommand : Command
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
}
