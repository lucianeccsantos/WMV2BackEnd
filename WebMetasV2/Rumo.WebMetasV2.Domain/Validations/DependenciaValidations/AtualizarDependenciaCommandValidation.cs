using Rumo.WebMetasV2.Domain.Commands.DependenciaCommands;

namespace Rumo.WebMetasV2.Domain.Validations.DependenciaValidations
{
    public class AtualizarDependenciaCommandValidation : DependenciaValidation<AtualizarDependenciaCommand>
    {
        public AtualizarDependenciaCommandValidation()
        {
            ValidateId();
            ValidateNome();
        }
    }
}
