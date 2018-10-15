using Rumo.WebMetasV2.Domain.Commands.FluxoAprovacaoEtapaCommands;

namespace Rumo.WebMetasV2.Domain.Validations.FluxoAprovacaoEtapaValidations
{
    public class RemoverFluxoAprovacaoEtapaCommandValidation : FluxoAprovacaoEtapaValidation<RemoverFluxoAprovacaoEtapaCommand>
    {
        public RemoverFluxoAprovacaoEtapaCommandValidation()
        {
            ValidateId();
        }
    }
}
