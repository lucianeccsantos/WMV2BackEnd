using MediatR;
using Rumo.WebMetasV2.Domain.Events.GrupoPoolEvents;

namespace Rumo.WebMetasV2.Domain.EventHandlers
{
    public class GrupoPoolEventHandler :
        INotificationHandler<GrupoPoolRegisteredEvent>,
        INotificationHandler<GrupoPoolUpdatedEvent>,
        INotificationHandler<GrupoPoolRemovedEvent>
    {
        public void Handle(GrupoPoolRegisteredEvent message)
        {
            // Send some notification e-mail
        }

        public void Handle(GrupoPoolUpdatedEvent message)
        {
            // Send some greetings e-mail
        }

        public void Handle(GrupoPoolRemovedEvent message)
        {
            // Send some see you soon e-mail
        }
    }
}
