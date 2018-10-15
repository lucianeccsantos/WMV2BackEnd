using Rumo.WebMetasV2.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace Rumo.WebMetasV2.Domain.Models
{
    public class Indicador : Entity
    {
        public Indicador(Guid id, string nome, Enumeradores.Enumerador.DirecaoIndicador direcaoIndicador, 
                         Enumeradores.Enumerador.TipoIndicador tipoIndicador, Enumeradores.Enumerador.Mes mesInicio,
                         Enumeradores.Enumerador.Mes mesFim, string descricao, string formulaCalculo,
                         Enumeradores.Enumerador.Periodicidade periodicidade, Guid colaboradorId)
        {
            Id = id;
            Nome = nome;
            DirecaoIndicador = direcaoIndicador;
            TipoIndicador = tipoIndicador;
            MesInicio = mesInicio;
            MesFim = mesFim;
            Descricao = descricao;
            FormulaCalculo = formulaCalculo;
            Periodicidade = periodicidade;
            ColaboradorId = colaboradorId;
        }

        public Indicador() { }

        public string Nome { get; set; }
        public Enumeradores.Enumerador.DirecaoIndicador DirecaoIndicador { get; private set; }
        public Enumeradores.Enumerador.TipoIndicador TipoIndicador { get; private set; }
        public Enumeradores.Enumerador.Mes MesInicio { get; private set; }
        public Enumeradores.Enumerador.Mes MesFim { get; private set; }
        public string Descricao { get; private set; }
        public string FormulaCalculo { get; private set; }
        public Enumeradores.Enumerador.Periodicidade Periodicidade { get; private set; }
        public Guid ColaboradorId { get; set; }

        public virtual IEnumerable<IndicadorEscopoArea> IndicadorEscopoAreas { get; set; }
        public virtual Colaborador DonoIndicador { get; set; }
    }
}
