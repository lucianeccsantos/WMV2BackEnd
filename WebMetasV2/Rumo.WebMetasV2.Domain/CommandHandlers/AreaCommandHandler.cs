using MediatR;
using Rumo.WebMetasV2.Domain.Commands.AreaCommands;
using Rumo.WebMetasV2.Domain.Core.Bus;
using Rumo.WebMetasV2.Domain.Core.Notifications;
using Rumo.WebMetasV2.Domain.Events.AreaEvents;
using Rumo.WebMetasV2.Domain.Interfaces;
using Rumo.WebMetasV2.Domain.Models;
using System;

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

        public void Handle(CadastrarAreaCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var area = new Area(Guid.NewGuid(), message.Nome);

            _areaRepository.Add(area);

            if (Commit())
            {
                Bus.RaiseEvent(new AreaRegisteredEvent(area.Id, area.Nome));
            }
        }

        public void Handle(AtualizarAreaCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var area = new Area(message.Id, message.Nome);

            _areaRepository.Update(area);

            if (Commit())
            {
                Bus.RaiseEvent(new AreaUpdatedEvent(area.Id, area.Nome));
            }
        }

        public void Handle(RemoverAreaCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            _areaRepository.Remove(message.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new AreaRemovedEvent(message.Id));
            }
        }

        public void Dispose()
        {
            _areaRepository.Dispose();
        }

    }
}
