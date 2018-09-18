using Rumo.WebMetasV2.Domain.Validations.PerfilValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rumo.WebMetasV2.Domain.Commands.PerfilCommands
{
    public class AtualizarPerfilCommand : PerfilCommand
    {
        public AtualizarPerfilCommand(Guid id, string nome, bool situacao)
        {
            Id = id;
            Nome = nome;
            Situacao = situacao;
        }
        public override bool IsValid()
        {
            ValidationResult = new AtualizarPerfilCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
