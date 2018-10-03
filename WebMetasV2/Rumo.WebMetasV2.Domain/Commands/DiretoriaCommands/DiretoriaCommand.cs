using Rumo.WebMetasV2.Domain.Core.Commands;
using System;

namespace Rumo.WebMetasV2.Domain.Commands.DiretoriaCommands
{
    public abstract class DiretoriaCommand : Command
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
}
