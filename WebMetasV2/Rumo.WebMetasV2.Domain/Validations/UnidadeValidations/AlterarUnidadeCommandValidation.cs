using Rumo.WebMetasV2.Domain.Commands.UnidadeCommands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rumo.WebMetasV2.Domain.Validations.UnidadeValidations
{
    public class AlterarUnidadeCommandValidation: UnidadeValidation<AtualizarUnidadeCommand>
    {
        public AlterarUnidadeCommandValidation()
        {
            ValidarId();
            ValidarNome();
        }
    }
}
