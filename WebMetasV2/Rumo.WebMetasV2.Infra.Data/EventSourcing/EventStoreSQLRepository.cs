using Rumo.WebMetasV2.Domain.Core.Events;
using Rumo.WebMetasV2.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Rumo.WebMetasV2.Infra.Data.EventSourcing
{
    public class EventStoreSQLRepository : IEventStoreRepository
    {
        private readonly WebMetasContext _context;

        public EventStoreSQLRepository(WebMetasContext context)
        {
            _context = context;
        }

        public IList<StoredEvent> All(Guid aggregateId)
        {
            return (from e in _context.StoredEvent where e.AggregateId == aggregateId select e).ToList();
        }

        public void Store(StoredEvent theEvent)
        {
            _context.StoredEvent.Add(theEvent);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
