using Rumo.WebMetasV2.Domain.Validations.FluxoAprovacaoValidations;
using System;
using static Rumo.WebMetasV2.Domain.Enumeradores.Enumerador;

namespace Rumo.WebMetasV2.Domain.Commands.FluxoAprovacaoCommands
{
    public class AtualizarFluxoAprovacaoCommand : FluxoAprovacaoCommand
    {
        public AtualizarFluxoAprovacaoCommand(Guid id, Entidades entidade)
        {
            Id = id;
            Entidade = entidade;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new AtualizarFluxoAprovacaoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
