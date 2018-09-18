using Rumo.WebMetasV2.Domain.Commands.IndicadorEscopoAreaCommands;

namespace Rumo.WebMetasV2.Domain.Validations.IndicadorEscopoAreaValidations
{
    public class AtualizarIndicadorEscopoAreaCommandValidation : IndicadorEscopoAreaValidation<AtualizarIndicadorEscopoAreaCommand>
    {
        public AtualizarIndicadorEscopoAreaCommandValidation()
        {
            ValidateId();
            ValidateIdArea();
            ValidateIdEscopo();
            ValidateIdIndicador();
        }
    }
}
