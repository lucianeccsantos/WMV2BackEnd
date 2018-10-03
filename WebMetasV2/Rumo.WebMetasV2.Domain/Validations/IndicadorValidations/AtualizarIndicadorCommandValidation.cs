using Rumo.WebMetasV2.Domain.Commands.IndicadorCommands;

namespace Rumo.WebMetasV2.Domain.Validations.IndicadorValidations
{
    public class AtualizarIndicadorCommandValidation : IndicadorValidation<AtualizarIndicadorCommand>
    {
        public AtualizarIndicadorCommandValidation()
        {
            ValidateId();
            ValidateDirecaoIndicador();
            ValidateMesFim();
            ValidateMesInicio();
            ValidateNome();
            ValidateTipoIndicador();
            ValidateDescricao();
            ValidateFormulaCalculo();
            ValidatePeriodicidade();
        }
    }
}
