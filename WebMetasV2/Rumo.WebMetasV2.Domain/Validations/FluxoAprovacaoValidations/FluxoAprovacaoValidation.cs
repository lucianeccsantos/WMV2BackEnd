using FluentValidation;
using Rumo.WebMetasV2.Domain.Commands.FluxoAprovacaoCommands;
using System;

namespace Rumo.WebMetasV2.Domain.Validations.FluxoAprovacaoValidations
{
    public class FluxoAprovacaoValidation<T> : AbstractValidator<T> where T : FluxoAprovacaoCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateEntidade()
        {
            RuleFor(c => c.Entidade)
                .NotEmpty().WithMessage("A entidade é obrigatória")
                .IsInEnum().WithMessage("A entidade é inválida");
        }
    }
}
