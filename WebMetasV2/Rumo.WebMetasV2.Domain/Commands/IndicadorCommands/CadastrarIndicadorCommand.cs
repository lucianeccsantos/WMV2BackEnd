using Rumo.WebMetasV2.Domain.Validations.IndicadorValidations;
using System;

namespace Rumo.WebMetasV2.Domain.Commands.IndicadorCommands
{
    public class CadastrarIndicadorCommand : IndicadorCommand
    {
        public CadastrarIndicadorCommand(string nome, Enumeradores.Enumerador.DirecaoIndicador direcaoIndicador,
                                         Enumeradores.Enumerador.TipoIndicador tipoIndicador, Enumeradores.Enumerador.Mes mesInicio,
                                         Enumeradores.Enumerador.Mes mesFim)
        {
            Nome = nome;
            DirecaoIndicador = direcaoIndicador;
            TipoIndicador = tipoIndicador;
            MesInicio = mesInicio;
            MesFim = mesFim;
        }

        public override bool IsValid()
        {
            ValidationResult = new CadastrarIndicadorCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
