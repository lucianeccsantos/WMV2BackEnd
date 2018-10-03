using Rumo.WebMetasV2.Domain.Interfaces;
using Rumo.WebMetasV2.Domain.Models;
using Rumo.WebMetasV2.Infra.Data.Context;
using System.Linq;
using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Rumo.WebMetasV2.Infra.Data.Repository
{
    public class CargoRepository : Repository<Cargo>, ICargoRepository
    {
        private WebMetasContext _context;

        public CargoRepository(WebMetasContext context) : base(context)
        {
            _context = context;
        }

        public PagedResult<Cargo> ListForEntity(int page, int pageSize)
        {
            IQueryable<Cargo> query = from o in _context.Cargo.Include("GrupoPool") orderby o.Nome select o;

            var result = GetPagedResultForQuery(query, page, pageSize);
            return result;
        }
    }
}
