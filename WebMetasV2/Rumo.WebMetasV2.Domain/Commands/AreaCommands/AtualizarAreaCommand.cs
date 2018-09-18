using Rumo.WebMetasV2.Domain.Validations.AreaValidations;
using System;

namespace Rumo.WebMetasV2.Domain.Commands.AreaCommands
{
    public class AtualizarAreaCommand : AreaCommand
    {
        public AtualizarAreaCommand(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new AtualizarAreaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
