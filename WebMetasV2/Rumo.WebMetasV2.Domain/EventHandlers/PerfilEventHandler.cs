using MediatR;
using Rumo.WebMetasV2.Domain.Events.PerfilEvents;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rumo.WebMetasV2.Domain.EventHandlers
{
    public class PerfilEventHandler : INotificationHandler<PerfilRegisteredEvent>,
                                      INotificationHandler<PerfilUpdatedEvents>,
                                      INotificationHandler<PerfilRemovedEvents>
    {
        public Task Handle(PerfilRegisteredEvent message, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(PerfilUpdatedEvents message, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(PerfilRemovedEvents notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
