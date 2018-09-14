using MediatR;
using Rumo.WebMetasV2.Domain.Events.GrupoPoolEvents;
using System.Threading;
using System.Threading.Tasks;

namespace Rumo.WebMetasV2.Domain.EventHandlers
{
    public class GrupoPoolEventHandler :
        INotificationHandler<GrupoPoolRegisteredEvent>,
        INotificationHandler<GrupoPoolUpdatedEvent>,
        INotificationHandler<GrupoPoolRemovedEvent>
    {
        public Task Handle(GrupoPoolRegisteredEvent message, CancellationToken cancellationToken)
        {
            // Send some notification e-mail
            return Task.CompletedTask;
        }

        public Task Handle(GrupoPoolUpdatedEvent message, CancellationToken cancellationToken)
        {
            // Send some greetings e-mail
            return Task.CompletedTask;
        }

        public Task Handle(GrupoPoolRemovedEvent message, CancellationToken cancellationToken)
        {
            // Send some see you soon e-mail
            return Task.CompletedTask;
        }
    }
}
