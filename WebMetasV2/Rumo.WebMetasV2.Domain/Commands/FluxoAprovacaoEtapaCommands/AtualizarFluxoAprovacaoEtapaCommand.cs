using Rumo.WebMetasV2.Domain.Validations.FluxoAprovacaoEtapaValidations;
using System;
using static Rumo.WebMetasV2.Domain.Enumeradores.Enumerador;

namespace Rumo.WebMetasV2.Domain.Commands.FluxoAprovacaoEtapaCommands
{
    public class AtualizarFluxoAprovacaoEtapaCommand : FluxoAprovacaoEtapaCommand
    {
        public AtualizarFluxoAprovacaoEtapaCommand(Guid id, int ordem, TipoEtapa tipoEtapa, Responsavel responsavel,
                                                   Guid perfilId, bool aprovaTudo, Guid fluxoAprovacaoId)
        {
            Id = id;
            Ordem = ordem;
            TipoEtapa = tipoEtapa;
            Responsavel = responsavel;
            PerfilId = perfilId;
            AprovaTudo = aprovaTudo;
            FluxoAprovacaoId = fluxoAprovacaoId;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new AtualizarFluxoAprovacaoEtapaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
