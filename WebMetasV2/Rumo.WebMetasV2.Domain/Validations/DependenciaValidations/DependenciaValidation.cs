using FluentValidation;
using Rumo.WebMetasV2.Domain.Commands.DependenciaCommands;
using System;

namespace Rumo.WebMetasV2.Domain.Validations.DependenciaValidations
{
    public class DependenciaValidation<T> : AbstractValidator<T> where T : DependenciaCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O nome da dependência é obrigatória")
                .Length(2, 100).WithMessage("O nome da dependência deve ter, no máximo, 100 caracteres");
        }
    }
}
