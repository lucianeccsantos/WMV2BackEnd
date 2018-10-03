using Rumo.WebMetasV2.Domain.Core.Events;
using System;

namespace Rumo.WebMetasV2.Domain.Events.CargoEvents
{
    public class CargoRegisteredEvent : Event
    {
        public CargoRegisteredEvent(Guid id, string nome, Guid grupoPoolId)
        {
            Id = id;
            Nome = nome;
            GrupoPoolId = grupoPoolId;
            AggregateId = id;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Guid GrupoPoolId { get; set; }
    }
}
