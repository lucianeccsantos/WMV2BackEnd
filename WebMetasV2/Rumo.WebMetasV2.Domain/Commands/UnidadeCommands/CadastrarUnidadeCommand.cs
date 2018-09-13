using Rumo.WebMetasV2.Domain.Validations.UnidadeValidations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rumo.WebMetasV2.Domain.Commands.UnidadeCommands
{
    public class CadastrarUnidadeCommand : UnidadeCommand
    {
        public CadastrarUnidadeCommand( string nome)
        {
            Nome = nome;
        }

        public override bool IsValid()
        {
            ValidationResult = new CadastrarUnidadeCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
