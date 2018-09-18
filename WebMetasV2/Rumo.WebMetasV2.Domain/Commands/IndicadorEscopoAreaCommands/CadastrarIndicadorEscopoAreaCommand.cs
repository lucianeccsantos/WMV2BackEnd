using Rumo.WebMetasV2.Domain.Validations.IndicadorEscopoAreaValidations;
using System;

namespace Rumo.WebMetasV2.Domain.Commands.IndicadorEscopoAreaCommands
{
    public class CadastrarIndicadorEscopoAreaCommand : IndicadorEscopoAreaCommand
    {
        public CadastrarIndicadorEscopoAreaCommand(Guid idIndicador, Guid idEscopo, Guid idArea)
        {
            IdIndicador = idIndicador;
            IdEscopo = idEscopo;
            IdArea = idArea;
        }

        public override bool IsValid()
        {
            ValidationResult = new CadastrarIndicadorEscopoAreaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
