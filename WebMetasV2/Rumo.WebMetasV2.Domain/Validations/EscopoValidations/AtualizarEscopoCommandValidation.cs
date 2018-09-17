using Rumo.WebMetasV2.Domain.Commands.EscopoCommands;

namespace Rumo.WebMetasV2.Domain.Validations.EscopoValidations
{
    public class AtualizarEscopoCommandValidation : EscopoValidation<AtualizarEscopoCommand>
    {
        public AtualizarEscopoCommandValidation()
        {
            ValidateId();
            ValidateNome();
        }
    }
}
