using MediatR;
using Rumo.WebMetasV2.Domain.Commands.DependenciaCommands;
using Rumo.WebMetasV2.Domain.Core.Bus;
using Rumo.WebMetasV2.Domain.Core.Notifications;
using Rumo.WebMetasV2.Domain.Events.DependenciaEvents;
using Rumo.WebMetasV2.Domain.Interfaces;
using Rumo.WebMetasV2.Domain.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Rumo.WebMetasV2.Domain.CommandHandlers
{
    public class DependenciaCommandHandler : CommandHandler,
        INotificationHandler<CadastrarDependenciaCommand>,
        INotificationHandler<AtualizarDependenciaCommand>,
        INotificationHandler<RemoverDependenciaCommand>
    {
        private readonly IDependenciaRepository _dependenciaRepository;
        private readonly IMediatorHandler Bus;

        public DependenciaCommandHandler(IDependenciaRepository dependenciaRepository,
                                         IUnitOfWork uow,
                                         IMediatorHandler bus,
                                         INotificationHandler<DomainNotification> notifications) :base(uow, bus, notifications)
        {
            _dependenciaRepository = dependenciaRepository;
            Bus = bus;
        }

        public Task Handle(CadastrarDependenciaCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            var dependencia = new Dependencia(Guid.NewGuid(), message.Nome);

            _dependenciaRepository.Add(dependencia);

            if (Commit())
            {
                Bus.RaiseEvent(new DependenciaRegisteredEvent(dependencia.Id, dependencia.Nome));
                return Task.CompletedTask;
            }

            return Task.CompletedTask;
        }

        public Task Handle(AtualizarDependenciaCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            var dependencia = new Dependencia(message.Id, message.Nome);

            _dependenciaRepository.Update(dependencia);

            if (Commit())
            {
                Bus.RaiseEvent(new DependenciaUpdatedEvent(dependencia.Id, dependencia.Nome));
                return Task.CompletedTask;
            }

            return Task.CompletedTask;
        }

        public Task Handle(RemoverDependenciaCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            _dependenciaRepository.Remove(message.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new DependenciaRemovedEvent(message.Id));
                return Task.CompletedTask;
            }

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _dependenciaRepository.Dispose();
        }
    }
}
