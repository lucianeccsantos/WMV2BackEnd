using Rumo.WebMetasV2.Domain.Commands.UnidadeCommands;
using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace Rumo.WebMetasV2.Domain.Validations.UnidadeValidations
{
    public abstract class UnidadeValidation<T> : AbstractValidator<T> where T : UnidadeCommand
    {
        protected void ValidarNome()
        {
            RuleFor(u => u.Nome)
            .NotEmpty().WithMessage("Informe o nome da Unidade")
            .Length(2,100).WithMessage("O nome deve conter entre 2 e 100 letras.");
        }

        protected void ValidarId()
        {
            RuleFor(u => u.Id)
            .NotEqual(Guid.Empty);
        }

    }
}
