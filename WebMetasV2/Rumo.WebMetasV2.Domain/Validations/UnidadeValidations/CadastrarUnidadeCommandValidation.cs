using Rumo.WebMetasV2.Domain.Commands.UnidadeCommands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rumo.WebMetasV2.Domain.Validations.UnidadeValidations
{
    public class CadastrarUnidadeCommandValidation : UnidadeValidation<CadastrarUnidadeCommand>
    {
        public CadastrarUnidadeCommandValidation()
        {
            ValidarNome();
        }
    }
}
