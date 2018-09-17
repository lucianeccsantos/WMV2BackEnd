using MediatR;
using Rumo.WebMetasV2.Domain.Events.AreaEvents;
using System.Threading.Tasks;
using System.Threading;

namespace Rumo.WebMetasV2.Domain.EventHandlers
{
    public class AreaEventHandler :
        INotificationHandler<AreaRegisteredEvent>,
        INotificationHandler<AreaUpdatedEvent>,
        INotificationHandler<AreaRemovedEvent>
    {
        public Task Handle(AreaRegisteredEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(AreaRemovedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(AreaUpdatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
