using Rumo.WebMetasV2.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace Rumo.WebMetasV2.Domain.Models
{
    public class Cargo : Entity
    {
        public Cargo(Guid id, string nome, Guid grupoPoolId)
        {
            Id = id;
            Nome = nome;
            GrupoPoolId = grupoPoolId;
        }

        public Cargo() { }

        public string Nome { get; set; }
        public Guid GrupoPoolId { get; set; }

        public virtual GrupoPool GrupoPool { get; set; }
        public IEnumerable<Colaborador> Colaboradores { get; set; }
    }
}
