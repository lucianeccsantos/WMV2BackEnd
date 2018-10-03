using Rumo.WebMetasV2.Domain.Core.Models;
using System;

namespace Rumo.WebMetasV2.Domain.Models
{
    public class Diretoria : Entity
    {
        public Diretoria(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public Diretoria() { }

        public string Nome { get; set; }
    }
}
