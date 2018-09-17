using MediatR;
using Rumo.WebMetasV2.Domain.Events.AreaEvents;

namespace Rumo.WebMetasV2.Domain.EventHandlers
{
    public class AreaEventHandler :
        INotificationHandler<AreaRegisteredEvent>,
        INotificationHandler<AreaUpdatedEvent>,
        INotificationHandler<AreaRemovedEvent>
    {
        public void Handle(AreaRegisteredEvent message)
        {
            // Send some notification e-mail
        }

        public void Handle(AreaUpdatedEvent message)
        {
            // Send some greetings e-mail
        }

        public void Handle(AreaRemovedEvent message)
        {
            // Send some see you soon e-mail
        }
    }
}
