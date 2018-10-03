using Rumo.WebMetasV2.Domain.Validations.DiretoriaValidations;

namespace Rumo.WebMetasV2.Domain.Commands.DiretoriaCommands
{
    public class CadastrarDiretoriaCommand : DiretoriaCommand
    {
        public CadastrarDiretoriaCommand(string nome)
        {
            Nome = nome;
        }

        public override bool IsValid()
        {
            ValidationResult = new CadastrarDiretoriaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
