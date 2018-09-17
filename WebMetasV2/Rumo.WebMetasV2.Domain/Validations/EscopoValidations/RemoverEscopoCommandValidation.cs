using Rumo.WebMetasV2.Domain.Commands.EscopoCommands;

namespace Rumo.WebMetasV2.Domain.Validations.EscopoValidations
{
    public class RemoverEscopoCommandValidation : EscopoValidation<RemoverEscopoCommand>
    {
        public RemoverEscopoCommandValidation()
        {
            ValidateId();
        }
    }
}
