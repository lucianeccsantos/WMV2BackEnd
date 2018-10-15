using Rumo.WebMetasV2.Domain.Validations.IndicadorEscopoAreaValidations;
using System;

namespace Rumo.WebMetasV2.Domain.Commands.IndicadorEscopoAreaCommands
{
    public class CadastrarIndicadorEscopoAreaCommand : IndicadorEscopoAreaCommand
    {
        public CadastrarIndicadorEscopoAreaCommand(Guid indicadorId, Guid escopoId, Guid areaId)
        {
            IndicadorId = indicadorId;
            EscopoId = escopoId;
            AreaId = areaId;
        }

        public override bool IsValid()
        {
            ValidationResult = new CadastrarIndicadorEscopoAreaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
