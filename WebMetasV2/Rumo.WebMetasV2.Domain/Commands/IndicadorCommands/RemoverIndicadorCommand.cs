using Rumo.WebMetasV2.Domain.Validations.IndicadorValidations;
using System;

namespace Rumo.WebMetasV2.Domain.Commands.IndicadorCommands
{
    public class RemoverIndicadorCommand : IndicadorCommand
    {
        public RemoverIndicadorCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoverIndicadorCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
