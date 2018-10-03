using Rumo.WebMetasV2.Domain.Validations.CargoValidations;
using System;

namespace Rumo.WebMetasV2.Domain.Commands.CargoCommands
{
    public class CadastrarCargoCommand : CargoCommand
    {
        public CadastrarCargoCommand(string nome, Guid grupoPoolId)
        {
            Nome = nome;
            GrupoPoolId = grupoPoolId;
        }

        public override bool IsValid()
        {
            ValidationResult = new CadastrarCargoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
