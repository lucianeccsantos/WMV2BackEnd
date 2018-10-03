using Microsoft.EntityFrameworkCore;
using Rumo.WebMetasV2.Domain.Interfaces;
using Rumo.WebMetasV2.Domain.Models;
using Rumo.WebMetasV2.Infra.Data.Context;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Rumo.WebMetasV2.Infra.Data.Repository
{
    public class ColaboradorRepository : Repository<Colaborador>, IColaboradorRepository
    {
        private WebMetasContext _context;

        public ColaboradorRepository(WebMetasContext context) : base(context)
        {
            _context = context;
        }

        public Colaborador ColaboradorESuperiorImediato(Guid id)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.SuperiorImediatoId == id);
        }

        public Colaborador GetByLogin(string login)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Login == login);
        }

        public PagedResult<Colaborador> ListForEntity(int page, int pageSize, params Expression<Func<Colaborador, object>>[] includes)
        {
            IQueryable<Colaborador> query = from o in _context.Colaborador orderby o.Nome select o;

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
