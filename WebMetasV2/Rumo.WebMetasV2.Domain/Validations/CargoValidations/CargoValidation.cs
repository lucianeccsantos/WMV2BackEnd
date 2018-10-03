using FluentValidation;
using Rumo.WebMetasV2.Domain.Commands.CargoCommands;
using System;

namespace Rumo.WebMetasV2.Domain.Validations.CargoValidations
{
    public class CargoValidation<T> : AbstractValidator<T> where T : CargoCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O nome do cargo é obrigatório")
                .Length(2, 100).WithMessage("O nome do cargo deve ter, no máximo, 100 caracteres");
        }

        protected void ValidateGrupoPool()
        {
            RuleFor(c => c.GrupoPoolId)
                .NotEqual(Guid.Empty).WithMessage("O Grupo de Pool é obrigatório");
        }
    }
}
