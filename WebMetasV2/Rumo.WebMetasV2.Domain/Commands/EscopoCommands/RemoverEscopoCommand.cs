using Rumo.WebMetasV2.Domain.Validations.EscopoValidations;
using System;

namespace Rumo.WebMetasV2.Domain.Commands.EscopoCommands
{
    public class RemoverEscopoCommand : EscopoCommand
    {
        public RemoverEscopoCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoverEscopoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
