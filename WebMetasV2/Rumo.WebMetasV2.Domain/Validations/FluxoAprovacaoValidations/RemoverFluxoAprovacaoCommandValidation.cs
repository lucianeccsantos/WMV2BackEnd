using Rumo.WebMetasV2.Domain.Commands.FluxoAprovacaoCommands;

namespace Rumo.WebMetasV2.Domain.Validations.FluxoAprovacaoValidations
{
    public class RemoverFluxoAprovacaoCommandValidation : FluxoAprovacaoValidation<RemoverFluxoAprovacaoCommand>
    {
        public RemoverFluxoAprovacaoCommandValidation()
        {
            ValidateId();
        }
    }
}
