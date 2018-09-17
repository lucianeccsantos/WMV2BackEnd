using Rumo.WebMetasV2.Domain.Models;

namespace Rumo.WebMetasV2.Domain.Interfaces
{
    public interface IAreaRepository : IRepository<Area>
    {
        PagedResult<Area> ListForEntity(int page, int pageSize);
    }
}
