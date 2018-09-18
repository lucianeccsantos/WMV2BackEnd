using Rumo.WebMetasV2.Domain.Enumeradores;
using System;

namespace Rumo.WebMetasV2.Application.ViewModels
{
    public class IndicadorViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Enumerador.DirecaoIndicador DirecaoIndicador { get; set; }
        public Enumerador.TipoIndicador TipoIndicador { get; set; }
        public Enumerador.Mes MesInicio { get; set; }
        public Enumerador.Mes MesFim { get; set; }
    }
}
