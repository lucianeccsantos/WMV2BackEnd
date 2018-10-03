using Rumo.WebMetasV2.Domain.Commands.DiretoriaCommands;

namespace Rumo.WebMetasV2.Domain.Validations.DiretoriaValidations
{
    public class AtualizarDiretoriaCommandValidation : DiretoriaValidation<AtualizarDiretoriaCommand>
    {
        public AtualizarDiretoriaCommandValidation()
        {
            ValidateId();
            ValidateNome();
        }
    }
}
