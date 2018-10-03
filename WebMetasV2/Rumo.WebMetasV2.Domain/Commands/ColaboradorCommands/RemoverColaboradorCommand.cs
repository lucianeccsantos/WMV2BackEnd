using Rumo.WebMetasV2.Domain.Validations.ColaboradorValidations;
using System;

namespace Rumo.WebMetasV2.Domain.Commands.ColaboradorCommands
{
    public class RemoverColaboradorCommand : ColaboradorCommand
    {
        public RemoverColaboradorCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoverColaboradorCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
