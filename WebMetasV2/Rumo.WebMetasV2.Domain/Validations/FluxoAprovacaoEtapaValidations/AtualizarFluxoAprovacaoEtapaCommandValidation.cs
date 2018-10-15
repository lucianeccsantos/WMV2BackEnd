using Rumo.WebMetasV2.Domain.Commands.FluxoAprovacaoEtapaCommands;

namespace Rumo.WebMetasV2.Domain.Validations.FluxoAprovacaoEtapaValidations
{
    public class AtualizarFluxoAprovacaoEtapaCommandValidation : FluxoAprovacaoEtapaValidation<AtualizarFluxoAprovacaoEtapaCommand>
    {
        public AtualizarFluxoAprovacaoEtapaCommandValidation()
        {
            ValidateAprovaTudo();
            ValidateFluxoAprovacao();
            ValidateId();
            ValidateOrdem();
            ValidateResponsavel();
            ValidateTipoEtapa();
        }
    }
}
