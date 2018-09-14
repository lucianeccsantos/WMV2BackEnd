using Rumo.WebMetasV2.Domain.Validations.GrupoPoolValidations;
using System;

namespace Rumo.WebMetasV2.Domain.Commands.GrupoPoolCommands
{
    public class RemoverGrupoPoolCommand : GrupoPoolCommand
    {
        public RemoverGrupoPoolCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoverGrupoPoolCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
