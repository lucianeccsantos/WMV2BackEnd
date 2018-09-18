using Rumo.WebMetasV2.Domain.Commands.IndicadorCommands;

namespace Rumo.WebMetasV2.Domain.Validations.IndicadorValidations
{
    public class RemoverIndicadorCommandValidation : IndicadorValidation<RemoverIndicadorCommand>
    {
        public RemoverIndicadorCommandValidation()
        {
            ValidateId();
        }
    }
}
