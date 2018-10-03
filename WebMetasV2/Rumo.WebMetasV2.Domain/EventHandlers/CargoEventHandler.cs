using MediatR;
using Rumo.WebMetasV2.Domain.Events.CargoEvents;
using System.Threading;
using System.Threading.Tasks;

namespace Rumo.WebMetasV2.Domain.EventHandlers
{
    public class CargoEventHandler :
        INotificationHandler<CargoRegisteredEvent>,
        INotificationHandler<CargoUpdatedEvent>,
        INotificationHandler<CargoRemovedEvent>
    {
        public Task Handle(CargoRegisteredEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(CargoUpdatedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(CargoRemovedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
