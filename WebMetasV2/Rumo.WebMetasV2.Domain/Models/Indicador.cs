using Rumo.WebMetasV2.Domain.Core.Models;
using System;

namespace Rumo.WebMetasV2.Domain.Models
{
    public class Indicador : Entity
    {
        public Indicador(Guid id, string nome, Enumeradores.Enumerador.DirecaoIndicador direcaoIndicador, 
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

        public Indicador() { }

        public string Nome { get; set; }
        public Enumeradores.Enumerador.DirecaoIndicador DirecaoIndicador { get; private set; }
        public Enumeradores.Enumerador.TipoIndicador TipoIndicador { get; private set; }
        public Enumeradores.Enumerador.Mes MesInicio { get; private set; }
        public Enumeradores.Enumerador.Mes MesFim { get; private set; }
    }
}
