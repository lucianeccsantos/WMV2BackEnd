using Rumo.WebMetasV2.Domain.Core.Events;
using System;

namespace Rumo.WebMetasV2.Domain.Events.DependenciaEvents
{
    public class DependenciaUpdatedEvent : Event
    {
        public DependenciaUpdatedEvent(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
            AggregateId = id;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
}
