using Rumo.WebMetasV2.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rumo.WebMetasV2.Domain.Events
{
    public class UnidadeRegisteredEvent : Event
    {
        public UnidadeRegisteredEvent(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
}
