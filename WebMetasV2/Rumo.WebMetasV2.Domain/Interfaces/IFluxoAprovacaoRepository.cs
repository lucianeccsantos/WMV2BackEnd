using Rumo.WebMetasV2.Domain.Models;

namespace Rumo.WebMetasV2.Domain.Interfaces
{
    public interface IFluxoAprovacaoRepository : IRepository<FluxoAprovacao>
    {
        PagedResult<FluxoAprovacao> ListForEntity(int page, int pageSize);
    }
}
