using Rumo.WebMetasV2.Domain.Commands.CargoCommands;

namespace Rumo.WebMetasV2.Domain.Validations.CargoValidations
{
    public class AtualizarCargoCommandValidation : CargoValidation<AtualizarCargoCommand>
    {
        public AtualizarCargoCommandValidation()
        {
            ValidateId();
            ValidateNome();
            ValidateGrupoPool();
        }
    }
}
