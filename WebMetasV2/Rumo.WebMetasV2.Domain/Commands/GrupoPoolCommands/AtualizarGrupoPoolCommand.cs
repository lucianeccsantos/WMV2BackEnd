using Rumo.WebMetasV2.Domain.Validations.GrupoPoolValidations;
using System;

namespace Rumo.WebMetasV2.Domain.Commands.GrupoPoolCommands
{
    public class AtualizarGrupoPoolCommand : GrupoPoolCommand
    {
        public AtualizarGrupoPoolCommand(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new AtualizarGrupoPoolCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
