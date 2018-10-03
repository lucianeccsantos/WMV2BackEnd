using Rumo.WebMetasV2.Domain.Commands.DiretoriaCommands;

namespace Rumo.WebMetasV2.Domain.Validations.DiretoriaValidations
{
    public class RemoverDiretoriaCommandValidation : DiretoriaValidation<RemoverDiretoriaCommand>
    {
        public RemoverDiretoriaCommandValidation()
        {
            ValidateId();
        }
    }
}
