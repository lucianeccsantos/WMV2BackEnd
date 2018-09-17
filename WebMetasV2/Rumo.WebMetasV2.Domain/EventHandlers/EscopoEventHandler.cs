using MediatR;
using Rumo.WebMetasV2.Domain.Events.EscopoEvents;

namespace Rumo.WebMetasV2.Domain.EventHandlers
{
    public class EscopoEventHandler :
        INotificationHandler<EscopoRegisteredEvent>,
        INotificationHandler<EscopoUpdatedEvent>,
        INotificationHandler<EscopoRemovedEvent>
    {
        public void Handle(EscopoRegisteredEvent message)
        {
            // Send some notification e-mail
        }

        public void Handle(EscopoUpdatedEvent message)
        {
            // Send some greetings e-mail
        }

        public void Handle(EscopoRemovedEvent message)
        {
            // Send some see you soon e-mail
        }
    }
}
