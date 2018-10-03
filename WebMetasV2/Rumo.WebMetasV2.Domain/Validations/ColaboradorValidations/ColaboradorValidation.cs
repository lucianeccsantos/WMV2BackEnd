using FluentValidation;
using Rumo.WebMetasV2.Domain.Commands.ColaboradorCommands;
using System;

namespace Rumo.WebMetasV2.Domain.Validations.ColaboradorValidations
{
    public class ColaboradorValidation<T> : AbstractValidator<T> where T : ColaboradorCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateCargo()
        {
            RuleFor(c => c.CargoId)
                .NotEqual(Guid.Empty).WithMessage("O cargo é obrigatório");
        }

        protected void ValidateCPF()
        {
            RuleFor(c => c.CPF).Must(Commons.ValidaCPF.IsCpf).WithMessage("CPF inválido");
        }

        protected void ValidateDependencia()
        {
            RuleFor(c => c.DependenciaId)
                .NotEqual(Guid.Empty).WithMessage("A dependência é obrigatória");
        }

        protected void ValidateEmail()
        {
            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("O email é obrigatório")
                .Length(2, 100).WithMessage("O email deve ter, no máximo, 100 caracteres");
        }

        protected void ValidatePerfil()
        {
            RuleFor(c => c.PerfilId)
                .NotEqual(Guid.Empty).WithMessage("O perfil é obrigatório");
        }

        protected void ValidateUnidade()
        {
            RuleFor(c => c.UnidadeId)
                .NotEqual(Guid.Empty).WithMessage("A unidade é obrigatória");
        }

        protected void ValidateSuperiorImediato()
        {
            RuleFor(c => c.SuperiorImediatoId)
                .NotEqual(Guid.Empty).WithMessage("O superior imediato é obrigatório");
        }

        protected void ValidateLogin()
        {
            RuleFor(c => c.Login)
                .NotEmpty().WithMessage("O login é obrigatório")
                .Length(8).WithMessage("O login deve ter 8 caracteres");
        }

        protected void ValidateNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O nome do colaborador é obrigatório")
                .Length(2, 100).WithMessage("O nome do colaborador deve ter, no máximo, 100 caracteres");
        }

        protected void ValidateCadastroIncompleto()
        {
            RuleFor(c => c.CadastroIncompleto)
                .NotEmpty().WithMessage("É obrigatório dizer se o cadastro está incompleto");
        }

        protected void ValidateAtivo()
        {
            RuleFor(c => c.Ativo)
                .NotEmpty().WithMessage("É obrigatório dizer se o cadastro está ativo");
        }

    }
}
