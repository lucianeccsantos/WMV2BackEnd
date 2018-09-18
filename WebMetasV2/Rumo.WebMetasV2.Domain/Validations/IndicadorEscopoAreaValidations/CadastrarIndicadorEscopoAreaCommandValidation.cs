using Rumo.WebMetasV2.Domain.Commands.IndicadorEscopoAreaCommands;

namespace Rumo.WebMetasV2.Domain.Validations.IndicadorEscopoAreaValidations
{
    public class CadastrarIndicadorEscopoAreaCommandValidation : IndicadorEscopoAreaValidation<CadastrarIndicadorEscopoAreaCommand>
    {
        public CadastrarIndicadorEscopoAreaCommandValidation()
        {
            ValidateIdArea();
            ValidateIdEscopo();
            ValidateIdIndicador();
        }
    }
}
