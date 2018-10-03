using Rumo.WebMetasV2.Domain.Interfaces;
using Rumo.WebMetasV2.Domain.Models;
using Rumo.WebMetasV2.Infra.Data.Context;
using System.Linq;

namespace Rumo.WebMetasV2.Infra.Data.Repository
{
    public class DependenciaRepository : Repository<Dependencia>, IDependenciaRepository
    {
        private WebMetasContext _context;

        public DependenciaRepository(WebMetasContext context) : base(context)
        {
            _context = context;
        }

        public PagedResult<Dependencia> ListForEntity(int page, int pageSize)
        {
            IQueryable<Dependencia> query = from o in _context.Dependencia orderby o.Nome select o;

            var result = GetPagedResultForQuery(query, page, pageSize);
            return result;
        }
    }
}
