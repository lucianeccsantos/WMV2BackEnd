using Rumo.WebMetasV2.Domain.Validations.DiretoriaValidations;
using System;

namespace Rumo.WebMetasV2.Domain.Commands.DiretoriaCommands
{
    public class RemoverDiretoriaCommand : DiretoriaCommand
    {
        public RemoverDiretoriaCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoverDiretoriaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
