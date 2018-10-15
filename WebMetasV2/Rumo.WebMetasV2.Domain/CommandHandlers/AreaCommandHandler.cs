using MediatR;
using Rumo.WebMetasV2.Domain.Commands.AreaCommands;
using Rumo.WebMetasV2.Domain.Core.Bus;
using Rumo.WebMetasV2.Domain.Core.Notifications;
using Rumo.WebMetasV2.Domain.Events.AreaEvents;
using Rumo.WebMetasV2.Domain.Interfaces;
using Rumo.WebMetasV2.Domain.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Rumo.WebMetasV2.Domain.CommandHandlers
{
    public class AreaCommandHandler : CommandHandler,
        INotificationHandler<CadastrarAreaCommand>,
        INotificationHandler<AtualizarAreaCommand>,
        INotificationHandler<RemoverAreaCommand>
    {
        private readonly IAreaRepository _areaRepository;
        private readonly IMediatorHandler Bus;

        public AreaCommandHandler(IAreaRepository areaRepository,
                                  IUnitOfWork uow,
                                  IMediatorHandler bus,
                                  INotificationHandler<DomainNotification> notifications) :base(uow, bus, notifications)
        {
            _areaRepository = areaRepository;
            Bus = bus;
        }

        public Task Handle(CadastrarAreaCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            var area = new Area(Guid.NewGuid(), message.Nome);

            if (_areaRepository.GetByNome(area.Nome) != null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "Já existe uma área com esse nome."));
                return Task.CompletedTask;
            }

            _areaRepository.Add(area);

            if (Commit())
            {
                Bus.RaiseEvent(new AreaRegisteredEvent(area.Id, area.Nome));
                return Task.CompletedTask;
            }

            return Task.CompletedTask;
        }

        public Task Handle(AtualizarAreaCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            var area = new Area(message.Id, message.Nome);

            if (_areaRepository.GetByNome(area.Nome) != null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "Já existe uma área com esse nome."));
                return Task.CompletedTask;
            }

            _areaRepository.Update(area);

            if (Commit())
            {
                Bus.RaiseEvent(new AreaUpdatedEvent(area.Id, area.Nome));
                return Task.CompletedTask;
            }

            return Task.CompletedTask;
        }

        public Task Handle(RemoverAreaCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            _areaRepository.Remove(message.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new AreaRemovedEvent(message.Id));
                return Task.CompletedTask;
            }

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _areaRepository.Dispose();
        }

    }
}
