using Rumo.WebMetasV2.Domain.Commands.PerfilCommands;
using Rumo.WebMetasV2.Domain.Validations.PerfilValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rumo.WebMetasV2.Domain.Validations.PerfilValidations
{
    public class RemoverPerfilCommandValidation : PerfilValidation<RemoverPerfilCommand>
    {
        public RemoverPerfilCommandValidation()
        {
            ValidarId();
        }
    }
}
