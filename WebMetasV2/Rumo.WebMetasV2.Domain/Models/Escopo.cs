using Rumo.WebMetasV2.Domain.Core.Models;
using System;

namespace Rumo.WebMetasV2.Domain.Models
{
    public class Escopo : Entity
    {
        public Escopo(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public Escopo() { }

        public string Nome { get; set; }
    }
}
