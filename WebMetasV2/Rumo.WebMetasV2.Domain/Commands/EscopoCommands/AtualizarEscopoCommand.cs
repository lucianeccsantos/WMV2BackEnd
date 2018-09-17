using Rumo.WebMetasV2.Domain.Validations.EscopoValidations;
using System;

namespace Rumo.WebMetasV2.Domain.Commands.EscopoCommands
{
    public class AtualizarEscopoCommand : EscopoCommand
    {
        public AtualizarEscopoCommand(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new AtualizarEscopoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
