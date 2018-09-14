using Rumo.WebMetasV2.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rumo.WebMetasV2.Domain.Interfaces
{
    public interface IUnidadeRepository : IRepository<Unidade>
    {
        PagedResult<Unidade> ListForEntity(int page, int pageSize);
    }
}
