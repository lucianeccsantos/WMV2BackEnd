using MediatR;
using Rumo.WebMetasV2.Domain.Commands.IndicadorEscopoAreaCommands;
using Rumo.WebMetasV2.Domain.Core.Bus;
using Rumo.WebMetasV2.Domain.Core.Notifications;
using Rumo.WebMetasV2.Domain.Events.IndicadorEscopoAreaEvents;
using Rumo.WebMetasV2.Domain.Interfaces;
using Rumo.WebMetasV2.Domain.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Rumo.WebMetasV2.Domain.CommandHandlers
{
    public class IndicadorEscopoAreaCommandHandler : CommandHandler,
        INotificationHandler<CadastrarIndicadorEscopoAreaCommand>,
        INotificationHandler<AtualizarIndicadorEscopoAreaCommand>,
        INotificationHandler<RemoverIndicadorEscopoAreaCommand>
    {
        private readonly IIndicadorEscopoAreaRepository _indicadorEscopoAreaRepository;
        private readonly IMediatorHandler Bus;

        public IndicadorEscopoAreaCommandHandler(IIndicadorEscopoAreaRepository indicadorEscopoAreaRepository,
                                                 IUnitOfWork uow,
                                                 IMediatorHandler bus,
                                                 INotificationHandler<DomainNotification> notifications) :base(uow, bus, notifications)
        {
            _indicadorEscopoAreaRepository = indicadorEscopoAreaRepository;
            Bus = bus;
        }

        public Task Handle(CadastrarIndicadorEscopoAreaCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            var indicadorEscopoArea = new IndicadorEscopoArea(Guid.NewGuid(), message.IdIndicador, message.IdEscopo, message.IdArea);

            _indicadorEscopoAreaRepository.Add(indicadorEscopoArea);

            if (Commit())
            {
                Bus.RaiseEvent(new IndicadorEscopoAreaRegisteredEvent(indicadorEscopoArea.Id, indicadorEscopoArea.IdIndicador, indicadorEscopoArea.IdEscopo,
                                                                      indicadorEscopoArea.IdArea));
                return Task.CompletedTask;
            }

            return Task.CompletedTask;
        }

        public Task Handle(AtualizarIndicadorEscopoAreaCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            var indicadorEscopoArea = new IndicadorEscopoArea(message.Id, message.IdIndicador, message.IdEscopo, message.IdArea);

            _indicadorEscopoAreaRepository.Update(indicadorEscopoArea);

            if (Commit())
            {
                Bus.RaiseEvent(new IndicadorEscopoAreaUpdatedEvent(message.Id, message.IdIndicador, message.IdEscopo, message.IdArea));
                return Task.CompletedTask;
            }

            return Task.CompletedTask;
        }

        public Task Handle(RemoverIndicadorEscopoAreaCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            _indicadorEscopoAreaRepository.Remove(message.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new IndicadorEscopoAreaRemovedEvent(message.Id));
                return Task.CompletedTask;
            }

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _indicadorEscopoAreaRepository.Dispose();
        }
    }
}
