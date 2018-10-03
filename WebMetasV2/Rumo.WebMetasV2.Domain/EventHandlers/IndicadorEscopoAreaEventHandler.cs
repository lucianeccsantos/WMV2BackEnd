using MediatR;
using Rumo.WebMetasV2.Domain.Events.IndicadorEscopoAreaEvents;
using System.Threading;
using System.Threading.Tasks;

namespace Rumo.WebMetasV2.Domain.EventHandlers
{
    public class IndicadorEscopoAreaEventHandler :
        INotificationHandler<IndicadorEscopoAreaRegisteredEvent>,
        INotificationHandler<IndicadorEscopoAreaUpdatedEvent>,
        INotificationHandler<IndicadorEscopoAreaRemovedEvent>
    {
        public Task Handle(IndicadorEscopoAreaRegisteredEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(IndicadorEscopoAreaUpdatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(IndicadorEscopoAreaRemovedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
