using Rumo.WebMetasV2.Domain.Models;

namespace Rumo.WebMetasV2.Domain.Interfaces
{
    public interface IEscopoRepository : IRepository<Escopo>
    {
        PagedResult<Escopo> ListForEntity(int page, int pageSize);
    }
}
