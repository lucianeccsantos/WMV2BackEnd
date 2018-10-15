using Rumo.WebMetasV2.Domain.Models;
using System;
using System.Linq.Expressions;

namespace Rumo.WebMetasV2.Domain.Interfaces
{
    public interface IIndicadorRepository : IRepository<Indicador>
    {
        PagedResult<Indicador> ListForEntity(int page, int pageSize, params Expression<Func<Indicador, object>>[] includes);
    }
}
