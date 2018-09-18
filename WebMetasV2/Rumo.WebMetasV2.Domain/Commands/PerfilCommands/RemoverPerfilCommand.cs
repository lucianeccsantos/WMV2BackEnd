using Rumo.WebMetasV2.Domain.Validations.PerfilValidations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rumo.WebMetasV2.Domain.Commands.PerfilCommands
{
    public class RemoverPerfilCommand : PerfilCommand
    {
        public RemoverPerfilCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoverPerfilCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
