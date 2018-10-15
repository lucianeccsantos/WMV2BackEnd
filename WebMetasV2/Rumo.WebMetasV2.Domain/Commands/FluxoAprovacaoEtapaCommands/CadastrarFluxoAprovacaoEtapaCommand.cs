using Rumo.WebMetasV2.Domain.Validations.FluxoAprovacaoEtapaValidations;
using System;
using static Rumo.WebMetasV2.Domain.Enumeradores.Enumerador;

namespace Rumo.WebMetasV2.Domain.Commands.FluxoAprovacaoEtapaCommands
{
    public class CadastrarFluxoAprovacaoEtapaCommand : FluxoAprovacaoEtapaCommand
    {
        public CadastrarFluxoAprovacaoEtapaCommand(int ordem, TipoEtapa tipoEtapa, Responsavel responsavel, 
                                                   Guid perfilId, bool aprovaTudo, Guid fluxoAprovacaoId)
        {
            Ordem = ordem;
            TipoEtapa = tipoEtapa;
            Responsavel = responsavel;
            PerfilId = perfilId;
            AprovaTudo = aprovaTudo;
            FluxoAprovacaoId = fluxoAprovacaoId;
        }

        public override bool IsValid()
        {
            ValidationResult = new CadastrarFluxoAprovacaoEtapaCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
