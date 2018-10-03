using Rumo.WebMetasV2.Domain.Validations.DependenciaValidations;

namespace Rumo.WebMetasV2.Domain.Commands.DependenciaCommands
{
    public class CadastrarDependenciaCommand : DependenciaCommand
    {
        public CadastrarDependenciaCommand(string nome)
        {
            Nome = nome;
        }

        public override bool IsValid()
        {
            ValidationResult = new CadastrarDependenciaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
