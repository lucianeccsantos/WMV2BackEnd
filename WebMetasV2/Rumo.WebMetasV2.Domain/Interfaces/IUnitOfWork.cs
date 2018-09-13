using Rumo.WebMetasV2.Domain.Core.Commands;
using System;

namespace Rumo.WebMetasV2.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}
