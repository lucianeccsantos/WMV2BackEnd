
using FluentValidation;
using Rumo.WebMetasV2.Domain.Commands.FluxoAprovacaoEtapaCommands;
using System;

namespace Rumo.WebMetasV2.Domain.Validations.FluxoAprovacaoEtapaValidations
{
    public class FluxoAprovacaoEtapaValidation<T> : AbstractValidator<T> where T : FluxoAprovacaoEtapaCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateOrdem()
        {
            RuleFor(c => c.Ordem)
                .NotEmpty().WithMessage("A ordem é obrigatória");
        }

        protected void ValidateTipoEtapa()
        {
            RuleFor(c => c.TipoEtapa)
                .IsInEnum().WithMessage("Tipo de Etapa Inválida");
        }

        protected void ValidateResponsavel()
        {
            RuleFor(c => c.Responsavel)
                .IsInEnum().WithMessage("Responsávavel inválido");
        }

        protected void ValidateAprovaTudo()
        {
            RuleFor(c => c.AprovaTudo)
                .NotNull().WithMessage("Deve informar se o responsável Aprova Tudo");
        }

        protected void ValidateFluxoAprovacao()
        {
            RuleFor(c => c.FluxoAprovacaoId)
                .NotEqual(Guid.Empty).WithMessage("O fluxo de aprovação é obrigatório");
        }
    }
}
