using Rumo.WebMetasV2.Domain.Core.Commands;
using System;

namespace Rumo.WebMetasV2.Domain.Commands.IndicadorCommands
{
    public abstract class IndicadorCommand : Command
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public Enumeradores.Enumerador.DirecaoIndicador DirecaoIndicador { get; set; }
        public Enumeradores.Enumerador.TipoIndicador TipoIndicador { get; set; }
        public Enumeradores.Enumerador.Mes MesInicio { get; set; }
        public Enumeradores.Enumerador.Mes MesFim { get; set; }
    }
}
