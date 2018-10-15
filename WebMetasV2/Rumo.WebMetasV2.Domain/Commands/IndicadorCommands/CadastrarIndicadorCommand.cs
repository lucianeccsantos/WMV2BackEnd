using Rumo.WebMetasV2.Domain.Validations.IndicadorValidations;

namespace Rumo.WebMetasV2.Domain.Commands.IndicadorCommands
{
    public class CadastrarIndicadorCommand : IndicadorCommand
    {
        public CadastrarIndicadorCommand(string nome, Enumeradores.Enumerador.DirecaoIndicador direcaoIndicador,
                                         Enumeradores.Enumerador.TipoIndicador tipoIndicador, Enumeradores.Enumerador.Mes mesInicio,
                                         Enumeradores.Enumerador.Mes mesFim, string descricao, string formulaCalculo,
                                         Enumeradores.Enumerador.Periodicidade periodicidade)
        {
            Nome = nome;
            DirecaoIndicador = direcaoIndicador;
            TipoIndicador = tipoIndicador;
            MesInicio = mesInicio;
            MesFim = mesFim;
            Descricao = descricao;
            FormulaCalculo = formulaCalculo;
            Periodicidade = periodicidade;
        }

        public override bool IsValid()
        {
            ValidationResult = new CadastrarIndicadorCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
