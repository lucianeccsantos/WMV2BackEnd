using MediatR;
using Rumo.WebMetasV2.Domain.Events.ColaboradorEvents;
using System.Threading;
using System.Threading.Tasks;

namespace Rumo.WebMetasV2.Domain.EventHandlers
{
    public class ColaboradorEventHandler :
        INotificationHandler<ColaboradorRegisteredEvent>,
        INotificationHandler<ColaboradorUpdatedEvent>,
        INotificationHandler<ColaboradorRemovedEvent>
    {
        public Task Handle(ColaboradorRegisteredEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(ColaboradorUpdatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(ColaboradorRemovedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
