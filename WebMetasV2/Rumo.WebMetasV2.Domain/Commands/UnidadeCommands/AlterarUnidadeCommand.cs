using Rumo.WebMetasV2.Domain.Validations.UnidadeValidations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rumo.WebMetasV2.Domain.Commands.UnidadeCommands
{
    public class AlterarUnidadeCommand : UnidadeCommand
    {
        public AlterarUnidadeCommand(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public override bool IsValid()
        {
            ValidationResult = new AlterarUnidadeCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
