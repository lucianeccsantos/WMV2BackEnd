using Rumo.WebMetasV2.Domain.Commands.DependenciaCommands;

namespace Rumo.WebMetasV2.Domain.Validations.DependenciaValidations
{
    public class RemoverDependenciaCommandValidation : DependenciaValidation<RemoverDependenciaCommand>
    {
        public RemoverDependenciaCommandValidation()
        {
            ValidateId();
        }
    }
}
