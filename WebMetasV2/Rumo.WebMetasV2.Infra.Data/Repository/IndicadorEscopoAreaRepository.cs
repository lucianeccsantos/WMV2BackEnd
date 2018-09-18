using Rumo.WebMetasV2.Domain.Interfaces;
using Rumo.WebMetasV2.Domain.Models;
using Rumo.WebMetasV2.Infra.Data.Context;

namespace Rumo.WebMetasV2.Infra.Data.Repository
{
    public class IndicadorEscopoAreaRepository : Repository<IndicadorEscopoArea>, IIndicadorEscopoAreaRepository
    {
        private readonly WebMetasContext _context;

        public IndicadorEscopoAreaRepository(WebMetasContext context) : base(context)
        {
            _context = context;
        }
    }
}
