using Rumo.WebMetasV2.Domain.Commands.CargoCommands;

namespace Rumo.WebMetasV2.Domain.Validations.CargoValidations
{
    public class CadastrarCargoCommandValidation : CargoValidation<CadastrarCargoCommand>
    {
        public CadastrarCargoCommandValidation()
        {
            ValidateNome();
            ValidateGrupoPool();
        }
    }
}
