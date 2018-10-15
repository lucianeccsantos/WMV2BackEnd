using Rumo.WebMetasV2.Domain.Validations.FluxoAprovacaoEtapaValidations;
using System;

namespace Rumo.WebMetasV2.Domain.Commands.FluxoAprovacaoEtapaCommands
{
    public class RemoverFluxoAprovacaoEtapaCommand : FluxoAprovacaoEtapaCommand
    {
        public RemoverFluxoAprovacaoEtapaCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoverFluxoAprovacaoEtapaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
