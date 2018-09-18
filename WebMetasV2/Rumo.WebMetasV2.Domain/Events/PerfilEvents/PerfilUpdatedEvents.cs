using Rumo.WebMetasV2.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rumo.WebMetasV2.Domain.Events.PerfilEvents
{
    public class PerfilUpdatedEvents : Event
    {
        public PerfilUpdatedEvents(Guid id, string nome, bool situacao)
        {
            Id = id;
            Nome = nome;
            Situacao = situacao;
        }
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public bool Situacao { get; set; }
    }
}
