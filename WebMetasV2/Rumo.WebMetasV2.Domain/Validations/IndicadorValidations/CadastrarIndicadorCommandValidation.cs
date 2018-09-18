using Rumo.WebMetasV2.Domain.Commands.IndicadorCommands;

namespace Rumo.WebMetasV2.Domain.Validations.IndicadorValidations
{
    public class CadastrarIndicadorCommandValidation : IndicadorValidation<CadastrarIndicadorCommand>
    {
        public CadastrarIndicadorCommandValidation()
        {
            ValidateDirecaoIndicador();
            ValidateMesFim();
            ValidateMesInicio();
            ValidateNome();
            ValidateTipoIndicador();
        }
    }
}
