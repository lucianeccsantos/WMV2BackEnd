using Rumo.WebMetasV2.Domain.Validations.ColaboradorValidations;
using System;

namespace Rumo.WebMetasV2.Domain.Commands.ColaboradorCommands
{
    public class CadastrarColaboradorCommand : ColaboradorCommand
    {
        public CadastrarColaboradorCommand(string login, string nome, Guid cargoId, string cpf, Guid dependenciaId, Guid perfilId,
                                           string email, Guid unidadeId, Nullable<Guid> superiorImediatoId, bool cadastroIncompleto, bool ativo)
        {
            Login = login;
            Nome = nome;
            CargoId = cargoId;
            CPF = cpf;
            DependenciaId = dependenciaId;
            Email = email;
            PerfilId = perfilId;
            UnidadeId = unidadeId;
            SuperiorImediatoId = superiorImediatoId;
            CadastroIncompleto = cadastroIncompleto;
            Ativo = ativo;
        }

        public override bool IsValid()
        {
            ValidationResult = new CadastrarColaboradorCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
