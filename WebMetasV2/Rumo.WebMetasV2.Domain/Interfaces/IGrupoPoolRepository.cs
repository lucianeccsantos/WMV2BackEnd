using Rumo.WebMetasV2.Domain.Models;

namespace Rumo.WebMetasV2.Domain.Interfaces
{
    public interface IGrupoPoolRepository : IRepository<GrupoPool>
    {
        PagedResult<GrupoPool> ListForEntity(int page, int pageSize);
    }
}
