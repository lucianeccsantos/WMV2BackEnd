using Rumo.WebMetasV2.Domain.Validations.AreaValidations;
using System;

namespace Rumo.WebMetasV2.Domain.Commands.AreaCommands
{
    public class CadastrarAreaCommand : AreaCommand
    {
        public CadastrarAreaCommand(string nome)
        {
            Nome = nome;
        }

        public override bool IsValid()
        {
            ValidationResult = new CadastrarAreaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
