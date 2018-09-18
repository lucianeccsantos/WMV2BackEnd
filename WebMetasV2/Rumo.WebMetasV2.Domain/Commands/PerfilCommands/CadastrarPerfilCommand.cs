using FluentValidation;
using Rumo.WebMetasV2.Domain.Validations.PerfilValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rumo.WebMetasV2.Domain.Commands.PerfilCommands
{
    public class CadastrarPerfilCommand : PerfilCommand
    {
        public CadastrarPerfilCommand(string nome, bool situacao)
        {
            Nome = nome;
            Situacao = situacao;
        }

        public override bool IsValid()
        {           
            ValidationResult = new CadastrarPerfilCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
