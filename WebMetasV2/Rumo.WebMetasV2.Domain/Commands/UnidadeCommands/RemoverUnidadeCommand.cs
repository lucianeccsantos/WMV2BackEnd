using Rumo.WebMetasV2.Domain.Validations.UnidadeValidations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rumo.WebMetasV2.Domain.Commands.UnidadeCommands
{
    public class RemoverUnidadeCommand : UnidadeCommand
    {
        public RemoverUnidadeCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoverUnidadeCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
