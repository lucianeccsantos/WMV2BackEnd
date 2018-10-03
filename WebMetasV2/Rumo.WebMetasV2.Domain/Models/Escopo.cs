using Rumo.WebMetasV2.Domain.Core.Models;
using System;
using System.Collections.Generic;

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

        public virtual IEnumerable<IndicadorEscopoArea> IndicadorEscopoAreas { get; set; }
    }
}
