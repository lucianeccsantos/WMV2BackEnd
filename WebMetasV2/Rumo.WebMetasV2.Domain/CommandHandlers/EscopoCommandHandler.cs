using MediatR;
using Rumo.WebMetasV2.Domain.Commands.EscopoCommands;
using Rumo.WebMetasV2.Domain.Core.Bus;
using Rumo.WebMetasV2.Domain.Core.Notifications;
using Rumo.WebMetasV2.Domain.Events.EscopoEvents;
using Rumo.WebMetasV2.Domain.Interfaces;
using Rumo.WebMetasV2.Domain.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

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

        public Task Handle(CadastrarEscopoCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            var escopo = new Escopo(Guid.NewGuid(), message.Nome);

            _escopoRepository.Add(escopo);

            if (Commit())
            {
                Bus.RaiseEvent(new EscopoRegisteredEvent(escopo.Id, escopo.Nome));
                return Task.CompletedTask;
            }

            return Task.CompletedTask;
        }

        public Task Handle(AtualizarEscopoCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            var escopo = new Escopo(message.Id, message.Nome);

            _escopoRepository.Update(escopo);

            if (Commit())
            {
                Bus.RaiseEvent(new EscopoUpdatedEvent(escopo.Id, escopo.Nome));
                return Task.CompletedTask;
            }

            return Task.CompletedTask;
        }

        public Task Handle(RemoverEscopoCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            _escopoRepository.Remove(message.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new EscopoRemovedEvent(message.Id));
                return Task.CompletedTask;
            }

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _escopoRepository.Dispose();
        }
    }
}
