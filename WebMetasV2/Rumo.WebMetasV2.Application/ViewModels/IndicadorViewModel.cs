using Rumo.WebMetasV2.Domain.Enumeradores;
using System;
using System.Collections.Generic;

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
        public string Descricao { get; set; }
        public string FormulaCalculo { get; set; }
        public Enumerador.Periodicidade Periodicidade { get; set; }
        public Guid ColaboradorId { get; set; }

        public IEnumerable<IndicadorEscopoAreaViewModel> IndicadorEscopoAreas { get; set; }
        public IEnumerable<EscopoViewModel> Escopos { get; set; }
        public ColaboradorViewModel DonoIndicador { get; set; }
    }
}
