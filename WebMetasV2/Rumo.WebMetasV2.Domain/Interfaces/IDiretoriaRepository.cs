using Rumo.WebMetasV2.Domain.Models;

namespace Rumo.WebMetasV2.Domain.Interfaces
{
    public interface IDiretoriaRepository : IRepository<Diretoria>
    {
        PagedResult<Diretoria> ListForEntity(int page, int pageSize);
    }
}
