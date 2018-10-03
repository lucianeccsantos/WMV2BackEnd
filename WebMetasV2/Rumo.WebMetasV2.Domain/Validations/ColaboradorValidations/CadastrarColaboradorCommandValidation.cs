using Rumo.WebMetasV2.Domain.Commands.ColaboradorCommands;

namespace Rumo.WebMetasV2.Domain.Validations.ColaboradorValidations
{
    public class CadastrarColaboradorCommandValidation : ColaboradorValidation<CadastrarColaboradorCommand>
    {
        public CadastrarColaboradorCommandValidation()
        {
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
