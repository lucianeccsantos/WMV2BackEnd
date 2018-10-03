using Rumo.WebMetasV2.Domain.Validations.DiretoriaValidations;
using System;

namespace Rumo.WebMetasV2.Domain.Commands.DiretoriaCommands
{
    public class AtualizarDiretoriaCommand : DiretoriaCommand
    {
        public AtualizarDiretoriaCommand(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new AtualizarDiretoriaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
