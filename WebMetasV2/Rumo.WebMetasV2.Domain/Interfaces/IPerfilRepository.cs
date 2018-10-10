using Rumo.WebMetasV2.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rumo.WebMetasV2.Domain.Interfaces
{
    public interface IPerfilRepository : IRepository<Perfil>
    {
        PagedResult<Perfil> ListForEntity(int page, int pageSize);
        PagedResult<Perfil> GetBy(Perfil perfil, int page, int pageSize);
    }
}
