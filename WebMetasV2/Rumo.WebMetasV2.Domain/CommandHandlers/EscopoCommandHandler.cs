using MediatR;
using Rumo.WebMetasV2.Domain.Commands.EscopoCommands;
using Rumo.WebMetasV2.Domain.Core.Bus;
using Rumo.WebMetasV2.Domain.Core.Notifications;
using Rumo.WebMetasV2.Domain.Events.EscopoEvents;
using Rumo.WebMetasV2.Domain.Interfaces;
using Rumo.WebMetasV2.Domain.Models;
using System;

namespace Rumo.WebMetasV2.Domain.CommandHandlers
{
    public class EscopoCommandHandler : CommandHandler,
        INotificationHandler<CadastrarEscopoCommand>,
        INotificationHandler<AtualizarEscopoCommand>,
        INotificationHandler<RemoverEscopoCommand>
    {
        private readonly IEscopoRepository _escopoRepository;
        private readonly IMediatorHandler Bus;

        public EscopoCommandHandler(IEscopoRepository escopoRepository,
                                    IUnitOfWork uow,
                                    IMediatorHandler bus,
                                    INotificationHandler<DomainNotification> notifications) :base(uow, bus, notifications)
        {
            _escopoRepository = escopoRepository;
            Bus = bus;
        }

        public void Handle(CadastrarEscopoCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var escopo = new Escopo(Guid.NewGuid(), message.Nome);

            _escopoRepository.Add(escopo);

            if (Commit())
            {
                Bus.RaiseEvent(new EscopoRegisteredEvent(escopo.Id, escopo.Nome));
            }
        }

        public void Handle(AtualizarEscopoCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var escopo = new Escopo(message.Id, message.Nome);

            _escopoRepository.Update(escopo);

            if (Commit())
            {
                Bus.RaiseEvent(new EscopoUpdatedEvent(escopo.Id, escopo.Nome));
            }
        }

        public void Handle(RemoverEscopoCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            _escopoRepository.Remove(message.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new EscopoRemovedEvent(message.Id));
            }
        }

        public void Dispose()
        {
            _escopoRepository.Dispose();
        }
    }
}
