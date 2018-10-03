using Rumo.WebMetasV2.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rumo.WebMetasV2.Domain.Models
{
   public class Perfil : Entity
    {
        public Perfil(Guid id, string nome,  bool situacao)
        {
            Id = id;
            Nome = nome;
            Situacao = situacao;
        }

        protected Perfil()
        { }

        public string Nome { get; private set; }
        public bool Situacao { get; private set; }
        public IEnumerable<Colaborador> Colaboradores { get; set; }
    }
}
