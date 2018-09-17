using Rumo.WebMetasV2.Domain.Commands.AreaCommands;

namespace Rumo.WebMetasV2.Domain.Validations.AreaValidations
{
    public class RemoverAreaCommandValidation : AreaValidation<RemoverAreaCommand>
    {
        public RemoverAreaCommandValidation()
        {
            ValidateId();
        }
    }
}
