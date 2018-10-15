using Rumo.WebMetasV2.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rumo.WebMetasV2.Domain.Commands.PerfilCommands
{
    public abstract class PerfilCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Nome { get; set; }
        public bool Situacao { get; set; }
               
    }
}
