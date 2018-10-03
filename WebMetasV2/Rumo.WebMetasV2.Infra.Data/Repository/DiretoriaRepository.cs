using Rumo.WebMetasV2.Domain.Interfaces;
using Rumo.WebMetasV2.Domain.Models;
using Rumo.WebMetasV2.Infra.Data.Context;
using System.Linq;

namespace Rumo.WebMetasV2.Infra.Data.Repository
{
    public class DiretoriaRepository : Repository<Diretoria>, IDiretoriaRepository
    {
        private WebMetasContext _context;

        public DiretoriaRepository(WebMetasContext context) : base(context)
        {
            _context = context;
        }

        public PagedResult<Diretoria> ListForEntity(int page, int pageSize)
        {
            IQueryable<Diretoria> query = from o in _context.Diretoria orderby o.Nome select o;

            var result = GetPagedResultForQuery(query, page, pageSize);
            return result;
        }
    }
}
