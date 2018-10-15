using Rumo.WebMetasV2.Domain.Interfaces;
using Rumo.WebMetasV2.Domain.Models;
using Rumo.WebMetasV2.Infra.Data.Context;
using System.Linq;

namespace Rumo.WebMetasV2.Infra.Data.Repository
{
    public class FluxoAprovacaoRepository : Repository<FluxoAprovacao>, IFluxoAprovacaoRepository
    {
        private WebMetasContext _context;

        public FluxoAprovacaoRepository(WebMetasContext context) : base(context)
        {
            _context = context;
        }

        public PagedResult<FluxoAprovacao> ListForEntity(int page, int pageSize)
        {
            IQueryable<FluxoAprovacao> query = from o in _context.FluxoAprovacao orderby o.Entidade select o;

            var result = GetPagedResultForQuery(query, page, pageSize);
            return result;
        }
    }
}
