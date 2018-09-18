using FluentValidation;
using Rumo.WebMetasV2.Domain.Commands.AreaCommands;
using System;

namespace Rumo.WebMetasV2.Domain.Validations.AreaValidations
{
    public class AreaValidation<T> : AbstractValidator<T> where T : AreaCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O nome da área é obrigatório")
                .Length(2, 100).WithMessage("O nome da área deve ter, no máximo, 100 caracteres");
        }
    }
}
