using Rumo.WebMetasV2.Domain.Core.Commands;
using Rumo.WebMetasV2.Domain.Interfaces;
using Rumo.WebMetasV2.Infra.Data.Context;

namespace Rumo.WebMetasV2.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WebMetasContext _context;

        public UnitOfWork(WebMetasContext context)
        {
            _context = context;
        }

        public CommandResponse Commit()
        {
            var rowsAffected = _context.SaveChanges();
            return new CommandResponse(rowsAffected > 0);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
