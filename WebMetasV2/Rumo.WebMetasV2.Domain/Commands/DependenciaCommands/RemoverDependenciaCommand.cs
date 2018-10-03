using Rumo.WebMetasV2.Domain.Validations.DependenciaValidations;
using System;

namespace Rumo.WebMetasV2.Domain.Commands.DependenciaCommands
{
    public class RemoverDependenciaCommand : DependenciaCommand
    {
        public RemoverDependenciaCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoverDependenciaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
