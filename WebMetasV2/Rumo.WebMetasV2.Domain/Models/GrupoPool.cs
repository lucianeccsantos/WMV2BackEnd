using Rumo.WebMetasV2.Domain.Core.Models;
using System;
using System.Collections.Generic;

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

        public virtual IEnumerable<Cargo> Cargos { get; set; }
    }
}
