using Rumo.WebMetasV2.Domain.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Rumo.WebMetasV2.Domain.Interfaces
{
    public interface ICargoRepository : IRepository<Cargo>
    {
        PagedResult<Cargo> ListForEntity(int page, int pageSize);
    }
}
