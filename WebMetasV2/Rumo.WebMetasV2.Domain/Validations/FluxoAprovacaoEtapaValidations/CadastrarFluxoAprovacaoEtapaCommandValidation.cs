using Rumo.WebMetasV2.Domain.Commands.FluxoAprovacaoEtapaCommands;

namespace Rumo.WebMetasV2.Domain.Validations.FluxoAprovacaoEtapaValidations
{
    public class CadastrarFluxoAprovacaoEtapaCommandValidation : FluxoAprovacaoEtapaValidation<CadastrarFluxoAprovacaoEtapaCommand>
    {
        public CadastrarFluxoAprovacaoEtapaCommandValidation()
        {
            ValidateAprovaTudo();
            ValidateFluxoAprovacao();
            ValidateOrdem();
            ValidateResponsavel();
            ValidateTipoEtapa();
        }
    }
}
