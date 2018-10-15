using Rumo.WebMetasV2.Domain.Interfaces;
using Rumo.WebMetasV2.Domain.Models;
using Rumo.WebMetasV2.Infra.Data.Context;

namespace Rumo.WebMetasV2.Infra.Data.Repository
{
    public class FluxoAprovacaoEtapaRepository : Repository<FluxoAprovacaoEtapa>, IFluxoAprovacaoEtapaRepository
    {
        private WebMetasContext _context;

        public FluxoAprovacaoEtapaRepository(WebMetasContext context) : base(context)
        {
            _context = context;
        }
    }
}
