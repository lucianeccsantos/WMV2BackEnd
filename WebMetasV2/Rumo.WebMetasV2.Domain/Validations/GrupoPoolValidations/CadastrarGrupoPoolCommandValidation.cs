using Rumo.WebMetasV2.Domain.Commands.GrupoPoolCommands;

namespace Rumo.WebMetasV2.Domain.Validations.GrupoPoolValidations
{
    public class CadastrarGrupoPoolCommandValidation : GrupoPoolValidation<CadastrarGrupoPoolCommand>
    {
        public CadastrarGrupoPoolCommandValidation()
        {
            ValidateNome();
        }
    }
}
