using FluentValidation;
using Rumo.WebMetasV2.Domain.Commands.EscopoCommands;
using System;

namespace Rumo.WebMetasV2.Domain.Validations.EscopoValidations
{
    public class EscopoValidation<T> : AbstractValidator<T> where T : EscopoCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O nome do escopo é obrigatório")
                .Length(2, 100).WithMessage("O nome do escopo deve ter, no máximo, 100 caracteres");
        }
    }
}
