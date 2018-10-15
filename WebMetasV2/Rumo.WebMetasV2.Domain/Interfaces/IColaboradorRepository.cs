using Rumo.WebMetasV2.Domain.Models;
using System;
using System.Linq.Expressions;

namespace Rumo.WebMetasV2.Domain.Interfaces
{
    public interface IColaboradorRepository : IRepository<Colaborador>
    {
        PagedResult<Colaborador> ListForEntity(int page, int pageSize, params Expression<Func<Colaborador, object>>[] includes);
        Colaborador GetByLogin(string login);
        Colaborador ColaboradorESuperiorImediato(Guid id);
        Colaborador GetByCargo(Guid idCargo);
    }
}
