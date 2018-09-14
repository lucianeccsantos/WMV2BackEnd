using MediatR;
using Rumo.WebMetasV2.Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;


namespace Rumo.WebMetasV2.Domain.EventHandlers
{
    public class UnidadeEventHandler : INotificationHandler<UnidadeRegisteredEvent>,
                                        INotificationHandler<UnidadeRemovedEvent>,
                                        INotificationHandler<UnidadeUpdatedEvent>
    {
        public Task Handle(UnidadeRegisteredEvent message, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(UnidadeRemovedEvent message, CancellationToken cancelattionToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(UnidadeUpdatedEvent message, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

    }
}
