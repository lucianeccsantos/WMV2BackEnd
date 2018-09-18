using Rumo.WebMetasV2.Domain.Validations.IndicadorEscopoAreaValidations;
using System;

namespace Rumo.WebMetasV2.Domain.Commands.IndicadorEscopoAreaCommands
{
    public class RemoverIndicadorEscopoAreaCommand : IndicadorEscopoAreaCommand
    {
        public RemoverIndicadorEscopoAreaCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoverIndicadorEscopoAreaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
