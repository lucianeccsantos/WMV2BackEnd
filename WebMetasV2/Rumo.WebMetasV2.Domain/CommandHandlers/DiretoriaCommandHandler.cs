using MediatR;
using Rumo.WebMetasV2.Domain.Commands.DiretoriaCommands;
using Rumo.WebMetasV2.Domain.Core.Bus;
using Rumo.WebMetasV2.Domain.Core.Notifications;
using Rumo.WebMetasV2.Domain.Events.DiretoriaEvents;
using Rumo.WebMetasV2.Domain.Interfaces;
using Rumo.WebMetasV2.Domain.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Rumo.WebMetasV2.Domain.CommandHandlers
{
    public class DiretoriaCommandHandler : CommandHandler,
        INotificationHandler<CadastrarDiretoriaCommand>,
        INotificationHandler<AtualizarDiretoriaCommand>,
        INotificationHandler<RemoverDiretoriaCommand>
    {
        private readonly IDiretoriaRepository _diretoriaRepository;
        private readonly IMediatorHandler Bus;

        public DiretoriaCommandHandler(IDiretoriaRepository diretoriaRepository,
                                       IUnitOfWork uow,
                                       IMediatorHandler bus,
                                       INotificationHandler<DomainNotification> notifications) :base(uow, bus, notifications)
        {
            _diretoriaRepository = diretoriaRepository;
            Bus = bus;
        }

        public Task Handle(CadastrarDiretoriaCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            var diretoria = new Diretoria(Guid.NewGuid(), message.Nome);

            _diretoriaRepository.Add(diretoria);

            if (Commit())
            {
                Bus.RaiseEvent(new DiretoriaRegisteredEvent(diretoria.Id, diretoria.Nome));
                return Task.CompletedTask;
            }

            return Task.CompletedTask;
        }

        public Task Handle(AtualizarDiretoriaCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            var diretoria = new Diretoria(message.Id, message.Nome);

            _diretoriaRepository.Update(diretoria);

            if (Commit())
            {
                Bus.RaiseEvent(new DiretoriaUpdatedEvent(diretoria.Id, diretoria.Nome));
                return Task.CompletedTask;
            }

            return Task.CompletedTask;
        }

        public Task Handle(RemoverDiretoriaCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            _diretoriaRepository.Remove(message.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new DiretoriaRemovedEvent(message.Id));
                return Task.CompletedTask;
            }

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _diretoriaRepository.Dispose();
        }
    }
}
