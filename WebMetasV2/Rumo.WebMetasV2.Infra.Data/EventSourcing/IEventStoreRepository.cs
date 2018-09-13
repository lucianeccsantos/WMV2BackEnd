using Rumo.WebMetasV2.Domain.Core.Events;
using System;
using System.Collections.Generic;

namespace Rumo.WebMetasV2.Infra.Data.EventSourcing
{
    public interface IEventStoreRepository : IDisposable
    {
        void Store(StoredEvent theEvent);
        IList<StoredEvent> All(Guid aggregateId);
    }
}
