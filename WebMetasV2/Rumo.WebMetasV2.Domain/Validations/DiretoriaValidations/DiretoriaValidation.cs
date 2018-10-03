using FluentValidation;
using Rumo.WebMetasV2.Domain.Commands.DiretoriaCommands;
using System;

namespace Rumo.WebMetasV2.Domain.Validations.DiretoriaValidations
{
    public class DiretoriaValidation<T> : AbstractValidator<T> where T : DiretoriaCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O nome da diretoria é obrigatória")
                .Length(2, 100).WithMessage("O nome da diretoria deve ter, no máximo, 100 caracteres");
        }
    }
}
