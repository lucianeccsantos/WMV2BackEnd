using Rumo.WebMetasV2.Domain.Models;

namespace Rumo.WebMetasV2.Domain.Interfaces
{
    public interface IIndicadorRepository : IRepository<Indicador>
    {
        PagedResult<Indicador> ListForEntity(int page, int pageSize);
    }
}
