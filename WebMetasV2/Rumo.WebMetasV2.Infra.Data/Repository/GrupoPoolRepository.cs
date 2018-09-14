using Rumo.WebMetasV2.Domain.Interfaces;
using Rumo.WebMetasV2.Domain.Models;
using Rumo.WebMetasV2.Infra.Data.Context;
using System.Linq;

namespace Rumo.WebMetasV2.Infra.Data.Repository
{
    public class GrupoPoolRepository : Repository<GrupoPool>, IGrupoPoolRepository
    {
        private WebMetasContext _context;

        public GrupoRepository(WebMetasContext context) : base(context)
        {
            _context = context;
        }

        public PagedResult<GrupoPool> ListForEntity(int page, int pageSize)
        {
            IQueryable<GrupoPool> query = from o in _context.GrupoPool orderby o.Nome select o;

            var result = GetPagedResultForQuery(query, page, pageSize);
            return result;
        }
    }
}
