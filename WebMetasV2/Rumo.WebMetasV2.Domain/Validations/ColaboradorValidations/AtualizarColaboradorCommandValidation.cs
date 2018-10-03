using Rumo.WebMetasV2.Domain.Commands.ColaboradorCommands;

namespace Rumo.WebMetasV2.Domain.Validations.ColaboradorValidations
{
    public class AtualizarColaboradorCommandValidation : ColaboradorValidation<AtualizarColaboradorCommand>
    {
        public AtualizarColaboradorCommandValidation()
        {
            ValidateId();
            ValidateCargo();
            ValidateCPF();
            ValidateDependencia();
            ValidateEmail();
            ValidateLogin();
            ValidateNome();
            ValidatePerfil();
            ValidateUnidade();
        }
    }
}
