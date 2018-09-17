using Rumo.WebMetasV2.Domain.Interfaces;
using Rumo.WebMetasV2.Domain.Models;
using Rumo.WebMetasV2.Infra.Data.Context;
using System.Linq;

namespace Rumo.WebMetasV2.Infra.Data.Repository
{
    public class AreaRepository : Repository<Area>, IAreaRepository
    {
        private WebMetasContext _context;

        public AreaRepository(WebMetasContext context) : base(context)
        {
            _context = context;
        }

        public PagedResult<Area> ListForEntity(int page, int pageSize)
        {
            IQueryable<Area> query = from o in _context.Area orderby o.Nome select o;

            var result = GetPagedResultForQuery(query, page, pageSize);
            return result;
        }
    }
}
