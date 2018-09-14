using Rumo.WebMetasV2.Domain.Commands.GrupoPoolCommands;

namespace Rumo.WebMetasV2.Domain.Validations.GrupoPoolValidations
{
    public class RemoverGrupoPoolCommandValidation : GrupoPoolValidation<RemoverGrupoPoolCommand>
    {
        public RemoverGrupoPoolCommandValidation()
        {
            ValidateId();
        }
    }
}
