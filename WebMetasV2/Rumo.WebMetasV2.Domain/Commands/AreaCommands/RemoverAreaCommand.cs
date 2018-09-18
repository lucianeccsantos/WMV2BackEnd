using Rumo.WebMetasV2.Domain.Validations.AreaValidations;
using System;

namespace Rumo.WebMetasV2.Domain.Commands.AreaCommands
{
    public class RemoverAreaCommand : AreaCommand
    {
        public RemoverAreaCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoverAreaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
