﻿using Rumo.WebMetasV2.Domain.Core.Events;
using System;

namespace Rumo.WebMetasV2.Domain.Events.IndicadorEvents
{
    public class IndicadorRegisteredEvent : Event
    {
        public IndicadorRegisteredEvent(Guid id, string nome, Enumeradores.Enumerador.DirecaoIndicador direcaoIndicador,
                                        Enumeradores.Enumerador.TipoIndicador tipoIndicador, Enumeradores.Enumerador.Mes mesInicio,
                                        Enumeradores.Enumerador.Mes mesFim)
        {
            Id = id;
            Nome = nome;
            DirecaoIndicador = direcaoIndicador;
            TipoIndicador = tipoIndicador;
            MesInicio = mesInicio;
            MesFim = mesFim;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Enumeradores.Enumerador.DirecaoIndicador DirecaoIndicador { get; set; }
        public Enumeradores.Enumerador.TipoIndicador TipoIndicador { get; set; }
        public Enumeradores.Enumerador.Mes MesInicio { get; set; }
        public Enumeradores.Enumerador.Mes MesFim { get; set; }
    }
}