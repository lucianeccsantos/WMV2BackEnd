using Rumo.WebMetasV2.Domain.Validations.FluxoAprovacaoValidations;
using System;

namespace Rumo.WebMetasV2.Domain.Commands.FluxoAprovacaoCommands
{
    public class RemoverFluxoAprovacaoCommand : FluxoAprovacaoCommand
    {
        public RemoverFluxoAprovacaoCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoverFluxoAprovacaoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
