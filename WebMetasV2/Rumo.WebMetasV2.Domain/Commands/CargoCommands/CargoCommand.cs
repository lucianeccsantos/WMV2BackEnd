using Rumo.WebMetasV2.Domain.Core.Commands;
using System;

namespace Rumo.WebMetasV2.Domain.Commands.CargoCommands
{
    public abstract class CargoCommand : Command
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Guid GrupoPoolId { get; set; }
    }
}
