using Rumo.WebMetasV2.Domain.Validations.FluxoAprovacaoValidations;
using static Rumo.WebMetasV2.Domain.Enumeradores.Enumerador;

namespace Rumo.WebMetasV2.Domain.Commands.FluxoAprovacaoCommands
{
    public class CadastrarFluxoAprovacaoCommand : FluxoAprovacaoCommand
    {
        public CadastrarFluxoAprovacaoCommand(Entidades entidade)
        {
            Entidade = entidade;
        }

        public override bool IsValid()
        {
            ValidationResult = new CadastrarFluxoAprovacaoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
