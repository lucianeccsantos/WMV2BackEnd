using Rumo.WebMetasV2.Domain.Core.Models;
using System;

namespace Rumo.WebMetasV2.Domain.Models
{
    public class Dependencia : Entity
    {
        public Dependencia(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public Dependencia() { }

        public string Nome { get; set; }
    }
}
