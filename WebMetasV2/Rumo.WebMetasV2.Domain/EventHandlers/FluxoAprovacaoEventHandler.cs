using MediatR;
using Rumo.WebMetasV2.Domain.Events.FluxoAprovacaoEvents;
using System.Threading;
using System.Threading.Tasks;

namespace Rumo.WebMetasV2.Domain.EventHandlers
{
    public class FluxoAprovacaoEventHandler :
        INotificationHandler<FluxoAprovacaoRegisteredEvent>,
        INotificationHandler<FluxoAprovacaoUpdatedEvent>,
        INotificationHandler<FluxoAprovacaoRemovedEvent>
    {
        public Task Handle(FluxoAprovacaoRegisteredEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(FluxoAprovacaoUpdatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(FluxoAprovacaoRemovedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}