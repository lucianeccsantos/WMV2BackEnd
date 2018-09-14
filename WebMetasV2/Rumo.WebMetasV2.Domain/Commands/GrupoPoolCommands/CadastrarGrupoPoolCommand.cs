using System;

namespace Rumo.WebMetasV2.Domain.Commands.GrupoPoolCommands
{
    public class CadastrarGrupoPoolCommand : GrupoPoolCommand
    {
        public CadastrarGrupoPoolCommand(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public override bool IsValid()
        {
            throw new System.NotImplementedException();
        }
    }
}
