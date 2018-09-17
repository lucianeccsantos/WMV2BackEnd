using FluentValidation;
using Rumo.WebMetasV2.Domain.Commands.GrupoPoolCommands;
using System;

namespace Rumo.WebMetasV2.Domain.Validations.GrupoPoolValidations
{
    public class GrupoPoolValidation<T> : AbstractValidator<T> where T : GrupoPoolCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O nome do grupo de pool é obrigatório")
                .Length(2,100).WithMessage("O nome do grupo de pool deve ter, no máximo, 100 caracteres");
        }
    }
}
