using Rumo.WebMetasV2.Domain.Validations.DependenciaValidations;
using System;

namespace Rumo.WebMetasV2.Domain.Commands.DependenciaCommands
{
    public class AtualizarDependenciaCommand : DependenciaCommand
    {
        public AtualizarDependenciaCommand(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new AtualizarDependenciaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
