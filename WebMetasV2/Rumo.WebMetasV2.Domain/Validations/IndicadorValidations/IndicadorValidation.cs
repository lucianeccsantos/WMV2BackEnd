using FluentValidation;
using Rumo.WebMetasV2.Domain.Commands.IndicadorCommands;
using System;

namespace Rumo.WebMetasV2.Domain.Validations.IndicadorValidations
{
    public class IndicadorValidation<T> : AbstractValidator<T> where T : IndicadorCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O nome do indicador é obrigatório")
                .Length(2, 100).WithMessage("O nome do indicador deve ter, no máximo, 100 caracteres");
        }

        protected void ValidateDirecaoIndicador()
        {
            RuleFor(c => c.DirecaoIndicador)
                .IsInEnum().WithMessage("A direção do indicador é inválida");
        }

        protected void ValidateTipoIndicador()
        {
            RuleFor(c => c.TipoIndicador)
                .IsInEnum().WithMessage("O tipo do indicador é inválido");
        }

        protected void ValidateMesInicio()
        {
            RuleFor(c => c.MesInicio)
                .IsInEnum().WithMessage("O mês de início é inválido");
        }

        protected void ValidateMesFim()
        {
            RuleFor(c => c.MesFim)
                .IsInEnum().WithMessage("O mês de fim é inválido");
        }
    }
}
