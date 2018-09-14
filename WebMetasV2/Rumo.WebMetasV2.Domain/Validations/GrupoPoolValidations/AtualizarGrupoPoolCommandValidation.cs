using Rumo.WebMetasV2.Domain.Commands.GrupoPoolCommands;

namespace Rumo.WebMetasV2.Domain.Validations.GrupoPoolValidations
{
    public class AtualizarGrupoPoolCommandValidation : GrupoPoolValidation<AtualizarGrupoPoolCommand>
    {
        public AtualizarGrupoPoolCommandValidation()
        {
            ValidateId();
            ValidateNome();
        }
    }
}
