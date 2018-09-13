using Rumo.WebMetasV2.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rumo.WebMetasV2.Domain.Commands.UnidadeCommands
{
    public abstract class UnidadeCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Nome { get; protected set; }
    }
}
