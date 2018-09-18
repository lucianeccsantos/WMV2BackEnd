using FluentValidation;
using Rumo.WebMetasV2.Domain.Commands.IndicadorEscopoAreaCommands;
using System;

namespace Rumo.WebMetasV2.Domain.Validations.IndicadorEscopoAreaValidations
{
    public class IndicadorEscopoAreaValidation<T> : AbstractValidator<T> where T : IndicadorEscopoAreaCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty).WithMessage("O id é obrigatório");
        }

        protected void ValidateIdIndicador()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty).WithMessage("O id do indicador é obrigatório");
        }

        protected void ValidateIdEscopo()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty).WithMessage("O id do escopo é obrigatório");
        }

        protected void ValidateIdArea()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty).WithMessage("O id da área é obrigatório"); ;
        }
    }
}
