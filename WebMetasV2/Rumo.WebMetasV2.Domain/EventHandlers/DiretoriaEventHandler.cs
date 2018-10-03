using MediatR;
using Rumo.WebMetasV2.Domain.Events.DiretoriaEvents;
using System.Threading;
using System.Threading.Tasks;

namespace Rumo.WebMetasV2.Domain.EventHandlers
{
    public class DiretoriaEventHandler :
        INotificationHandler<DiretoriaRegisteredEvent>,
        INotificationHandler<DiretoriaUpdatedEvent>,
        INotificationHandler<DiretoriaRemovedEvent>
    {
        public Task Handle(DiretoriaRegisteredEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(DiretoriaUpdatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(DiretoriaRemovedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
