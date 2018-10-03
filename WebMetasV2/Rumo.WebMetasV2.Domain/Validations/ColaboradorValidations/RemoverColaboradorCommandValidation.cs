using Rumo.WebMetasV2.Domain.Commands.ColaboradorCommands;

namespace Rumo.WebMetasV2.Domain.Validations.ColaboradorValidations
{
    public class RemoverColaboradorCommandValidation : ColaboradorValidation<RemoverColaboradorCommand>
    {
        public RemoverColaboradorCommandValidation()
        {
            ValidateId();
        }
    }
}
