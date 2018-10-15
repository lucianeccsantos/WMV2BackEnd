using Microsoft.EntityFrameworkCore;
using Rumo.WebMetasV2.Domain.Interfaces;
using Rumo.WebMetasV2.Domain.Models;
using Rumo.WebMetasV2.Infra.Data.Context;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Rumo.WebMetasV2.Infra.Data.Repository
{
    public class IndicadorRepository : Repository<Indicador>, IIndicadorRepository
    {
        private WebMetasContext _context;

        public IndicadorRepository(WebMetasContext context) : base(context)
        {
            _context = context;
        }

        public PagedResult<Indicador> ListForEntity(int page, int pageSize, params Expression<Func<Indicador, object>>[] includes)
        {
            IQueryable<Indicador> query = from o in _context.Indicador orderby o.Nome select o;

            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }

            var result = GetPagedResultForQuery(query, page, pageSize);
            return result;
        }
    }
}
