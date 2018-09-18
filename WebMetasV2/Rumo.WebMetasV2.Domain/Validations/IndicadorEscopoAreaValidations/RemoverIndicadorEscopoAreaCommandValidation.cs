using Rumo.WebMetasV2.Domain.Commands.IndicadorEscopoAreaCommands;

namespace Rumo.WebMetasV2.Domain.Validations.IndicadorEscopoAreaValidations
{
    public class RemoverIndicadorEscopoAreaCommandValidation : IndicadorEscopoAreaValidation<RemoverIndicadorEscopoAreaCommand>
    {
        public RemoverIndicadorEscopoAreaCommandValidation()
        {
            ValidateId();
        }
    }
}
