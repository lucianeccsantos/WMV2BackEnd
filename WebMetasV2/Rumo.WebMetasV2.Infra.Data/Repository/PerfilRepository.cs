using Rumo.WebMetasV2.Domain.Interfaces;
using Rumo.WebMetasV2.Domain.Models;
using Rumo.WebMetasV2.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rumo.WebMetasV2.Infra.Data.Repository
{
    public class PerfilRepository : Repository<Perfil>, IPerfilRepository
    {
        private WebMetasContext _context;
        public PerfilRepository(WebMetasContext context) : base(context)
        {
            _context = context;
        }

        public PagedResult<Perfil> ListForEntity(int page, int pageSize)
        {
            IQueryable<Perfil> query = from o in _context.Perfil orderby o.Nome select o;
            var result = GetPagedResultForQuery(query, page, pageSize);
            return result;
        }

        public PagedResult<Perfil> GetBy(Perfil perfil, int page, int pageSize)
        {

            Func<Perfil, bool> condition;

            if (perfil.Nome != null)
                condition = x => x.Nome.ToLower().Contains(perfil.Nome.ToLower()) && x.Situacao == perfil.Situacao;
            else
                condition = x => x.Situacao == perfil.Situacao;


            /* IQueryable<Perfil> query = from o in _context.Perfil
                                        where o.Situacao == perfil.Situacao &&
                                        (perfil.Nome != null && o.Nome == perfil.Nome)
                                        orderby o.Nome
                                        select o;
                                        */
            var result = FindBy(condition, page, pageSize);
            return result;
        }

        p
    }
}
