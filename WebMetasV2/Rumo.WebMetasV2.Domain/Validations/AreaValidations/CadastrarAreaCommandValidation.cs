using Rumo.WebMetasV2.Domain.Commands.AreaCommands;

namespace Rumo.WebMetasV2.Domain.Validations.AreaValidations
{
    public class CadastrarAreaCommandValidation : AreaValidation<CadastrarAreaCommand>
    {
        public CadastrarAreaCommandValidation()
        {
            ValidateNome();
        }
    }
}
