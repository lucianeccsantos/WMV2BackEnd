using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Rumo.WebMetasV2.Domain.Events.EscopoEvents;

namespace Rumo.WebMetasV2.Domain.EventHandlers
{
    public class EscopoEventHandler :
        INotificationHandler<EscopoRegisteredEvent>,
        INotificationHandler<EscopoUpdatedEvent>,
        INotificationHandler<EscopoRemovedEvent>
    {
        public Task Handle(EscopoRegisteredEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(EscopoUpdatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(EscopoRemovedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
