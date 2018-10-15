using Rumo.WebMetasV2.Domain.Commands.FluxoAprovacaoCommands;

namespace Rumo.WebMetasV2.Domain.Validations.FluxoAprovacaoValidations
{
    public class AtualizarFluxoAprovacaoCommandValidation : FluxoAprovacaoValidation<AtualizarFluxoAprovacaoCommand>
    {
        public AtualizarFluxoAprovacaoCommandValidation()
        {
            ValidateEntidade();
            ValidateId();
        }
    }
}
