using Rumo.WebMetasV2.Domain.Validations.CargoValidations;
using System;

namespace Rumo.WebMetasV2.Domain.Commands.CargoCommands
{
    public class AtualizarCargoCommand : CargoCommand
    {
        public AtualizarCargoCommand(Guid id, string nome, Guid grupoPoolId)
        {
            Id = id;
            Nome = nome;
            GrupoPoolId = grupoPoolId;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new AtualizarCargoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
