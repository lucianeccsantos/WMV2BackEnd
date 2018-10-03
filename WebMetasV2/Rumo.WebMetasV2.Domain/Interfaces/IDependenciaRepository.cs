using Rumo.WebMetasV2.Domain.Models;

namespace Rumo.WebMetasV2.Domain.Interfaces
{
    public interface IDependenciaRepository : IRepository<Dependencia>
    {
        PagedResult<Dependencia> ListForEntity(int page, int pageSize);
    }
}
