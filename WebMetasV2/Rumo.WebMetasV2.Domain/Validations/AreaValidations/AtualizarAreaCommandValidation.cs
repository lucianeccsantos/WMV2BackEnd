using Rumo.WebMetasV2.Domain.Commands.AreaCommands;

namespace Rumo.WebMetasV2.Domain.Validations.AreaValidations
{
    public class AtualizarAreaCommandValidation : AreaValidation<AtualizarAreaCommand>
    {
        public AtualizarAreaCommandValidation()
        {
            ValidateId();
            ValidateNome();
        }
    }
}
