using Rumo.WebMetasV2.Domain.Commands.CargoCommands;

namespace Rumo.WebMetasV2.Domain.Validations.CargoValidations
{
    public class RemoverCargoCommandValidation : CargoValidation<RemoverCargoCommand>
    {
        public RemoverCargoCommandValidation()
        {
            ValidateId();
        }
    }
}
