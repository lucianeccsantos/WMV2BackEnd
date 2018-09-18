using Rumo.WebMetasV2.Domain.Interfaces;
using Rumo.WebMetasV2.Domain.Models;
using Rumo.WebMetasV2.Infra.Data.Context;
using System.Linq;

namespace Rumo.WebMetasV2.Infra.Data.Repository
{
    public class EscopoRepository : Repository<Escopo>, IEscopoRepository
    {
        private WebMetasContext _context;

        public EscopoRepository(WebMetasContext context) : base(context)
        {
            _context = context;
        }

        public PagedResult<Escopo> ListForEntity(int page, int pageSize)
        {
            IQueryable<Escopo> query = from o in _context.Escopo orderby o.Nome select o;

            var result = GetPagedResultForQuery(query, page, pageSize);
            return result;
        }
    }
}
