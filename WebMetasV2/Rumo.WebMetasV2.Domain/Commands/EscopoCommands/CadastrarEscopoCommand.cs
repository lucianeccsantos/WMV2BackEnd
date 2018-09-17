using Rumo.WebMetasV2.Domain.Validations.EscopoValidations;

namespace Rumo.WebMetasV2.Domain.Commands.EscopoCommands
{
    public class CadastrarEscopoCommand : EscopoCommand
    {
        public CadastrarEscopoCommand(string nome)
        {
            Nome = nome;
        }

        public override bool IsValid()
        {
            ValidationResult = new CadastrarEscopoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
