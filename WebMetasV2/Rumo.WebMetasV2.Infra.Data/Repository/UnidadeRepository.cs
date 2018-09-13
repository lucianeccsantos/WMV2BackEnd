using Rumo.WebMetasV2.Domain.Interfaces;
using Rumo.WebMetasV2.Domain.Models;
using Rumo.WebMetasV2.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rumo.WebMetasV2.Infra.Data.Repository
{
    public class UnidadeRepository : Repository<Unidade>, IUnidadeRepository
    {

        private WebMetasContext _context;

        public UnidadeRepository(WebMetasContext context) : base(context)
        {
            _context = context;
        }

        public PagedResult<Unidade> ListForEntity(int page, int pageSize)
        {
            IQueryable<Unidade> query = from o in _context.Unidade orderby o.Nome select o;

            var result = GetPagedResultForQuery(query, page, pageSize);

            return result;
        }
    }
}
