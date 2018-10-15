using Rumo.WebMetasV2.Domain.Core.Models;
using Rumo.WebMetasV2.Domain.Enumeradores;
using System;
using System.Collections.Generic;

namespace Rumo.WebMetasV2.Domain.Models
{
    public class FluxoAprovacao : Entity
    {
        public FluxoAprovacao(Guid id, Enumerador.Entidades entidade)
        {
            Id = id;
            Entidade = entidade;
        }

        public Enumerador.Entidades Entidade { get; private set; }

        public virtual IEnumerable<FluxoAprovacaoEtapa> Etapas { get; set; }
    }
}
