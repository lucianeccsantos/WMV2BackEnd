using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Rumo.WebMetasV2.Domain.Events.IndicadorEvents;

namespace Rumo.WebMetasV2.Domain.EventHandlers
{
    public class IndicadorEventHandler :
        INotificationHandler<IndicadorRegisteredEvent>,
        INotificationHandler<IndicadorUpdatedEvent>,
        INotificationHandler<IndicadorRemovedEvent>
    {
        public Task Handle(IndicadorRegisteredEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(IndicadorUpdatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(IndicadorRemovedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
