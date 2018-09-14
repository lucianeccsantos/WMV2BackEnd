using Rumo.WebMetasV2.Domain.Core.Events;
using System;

namespace Rumo.WebMetasV2.Domain.Events.GrupoPoolEvents
{
    public class GrupoPoolRegisteredEvent : Event
    {
        public GrupoPoolRegisteredEvent(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
}
