using Rumo.WebMetasV2.Domain.Validations.IndicadorEscopoAreaValidations;
using System;

namespace Rumo.WebMetasV2.Domain.Commands.IndicadorEscopoAreaCommands
{
    public class AtualizarIndicadorEscopoAreaCommand : IndicadorEscopoAreaCommand
    {
        public AtualizarIndicadorEscopoAreaCommand(Guid id, Guid idIndicador, Guid idEscopo, Guid idArea)
        {
            Id = id;
            IdIndicador = idIndicador;
            IdEscopo = idEscopo;
            IdArea = idArea;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new AtualizarIndicadorEscopoAreaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
