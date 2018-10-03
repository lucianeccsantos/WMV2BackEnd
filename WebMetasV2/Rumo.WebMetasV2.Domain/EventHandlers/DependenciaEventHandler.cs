using MediatR;
using Rumo.WebMetasV2.Domain.Events.DependenciaEvents;
using System.Threading;
using System.Threading.Tasks;

namespace Rumo.WebMetasV2.Domain.EventHandlers
{
    public class DependenciaEventHandler :
        INotificationHandler<DependenciaRegisteredEvent>,
        INotificationHandler<DependenciaUpdatedEvent>,
        INotificationHandler<DependenciaRemovedEvent>
    {
        public Task Handle(DependenciaRegisteredEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(DependenciaUpdatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(DependenciaRemovedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
