using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Rumo.WebMetasV2.Domain.Commands.PerfilCommands;

namespace Rumo.WebMetasV2.Domain.Validations.PerfilValidation
{
    public abstract class PerfilValidation<T>: AbstractValidator<T> where T : PerfilCommand
    {
        public void ValidarNome()
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("Informe o nome do perfil.")
                .Length(2, 100).WithMessage("O nome do perfil deve ter entre 2 e 100 caracteres.");

        }
        public void ValidarId()
        {
            RuleFor(p => p.Id)
            .NotEqual(Guid.Empty);
        }

        public void ValidarSituacao()
        {
            RuleFor(p => p.Situacao)
            .NotNull();
        }
    }
}
