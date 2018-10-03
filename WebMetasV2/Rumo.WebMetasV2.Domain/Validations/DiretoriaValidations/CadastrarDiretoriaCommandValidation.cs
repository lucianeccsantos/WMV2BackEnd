using Rumo.WebMetasV2.Domain.Commands.DiretoriaCommands;

namespace Rumo.WebMetasV2.Domain.Validations.DiretoriaValidations
{
    public class CadastrarDiretoriaCommandValidation : DiretoriaValidation<CadastrarDiretoriaCommand>
    {
        public CadastrarDiretoriaCommandValidation()
        {
            ValidateNome();
        }
    }
}
