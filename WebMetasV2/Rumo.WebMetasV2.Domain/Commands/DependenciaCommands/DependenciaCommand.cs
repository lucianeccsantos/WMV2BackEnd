using Rumo.WebMetasV2.Domain.Core.Commands;
using System;

namespace Rumo.WebMetasV2.Domain.Commands.DependenciaCommands
{
    public abstract class DependenciaCommand : Command
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
}
