using Rumo.WebMetasV2.Domain.Core.Models;
using System;

namespace Rumo.WebMetasV2.Domain.Models
{
    public class GrupoPool : Entity
    {
        public GrupoPool(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public GrupoPool() { }

        public string Nome { get; private set; }
    }
}
