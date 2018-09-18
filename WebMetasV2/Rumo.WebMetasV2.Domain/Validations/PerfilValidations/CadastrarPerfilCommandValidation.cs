using Rumo.WebMetasV2.Domain.Commands.PerfilCommands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rumo.WebMetasV2.Domain.Validations.PerfilValidation
{
    public class CadastrarPerfilCommandValidation : PerfilValidation<CadastrarPerfilCommand>
    {
        public CadastrarPerfilCommandValidation()
        {
            ValidarNome();
            ValidarSituacao();
        }
    }
}
