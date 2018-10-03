using Rumo.WebMetasV2.Domain.Validations.CargoValidations;
using System;

namespace Rumo.WebMetasV2.Domain.Commands.CargoCommands
{
    public class RemoverCargoCommand : CargoCommand
    {
        public RemoverCargoCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoverCargoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
