using Rumo.WebMetasV2.Domain.Core.Events;
using System;

namespace Rumo.WebMetasV2.Domain.Events.DiretoriaEvents
{
    public class DiretoriaRegisteredEvent : Event
    {
        public DiretoriaRegisteredEvent(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
}
