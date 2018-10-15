using Rumo.WebMetasV2.Domain.Validations.IndicadorEscopoAreaValidations;
using System;

namespace Rumo.WebMetasV2.Domain.Commands.IndicadorEscopoAreaCommands
{
    public class AtualizarIndicadorEscopoAreaCommand : IndicadorEscopoAreaCommand
    {
        public AtualizarIndicadorEscopoAreaCommand(Guid id, Guid indicadorId, Guid escopoId, Guid areaId)
        {
            Id = id;
            IndicadorId = indicadorId;
            EscopoId = escopoId;
            AreaId = areaId;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new AtualizarIndicadorEscopoAreaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
