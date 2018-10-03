using MediatR;
using Rumo.WebMetasV2.Domain.Commands.CargoCommands;
using Rumo.WebMetasV2.Domain.Core.Bus;
using Rumo.WebMetasV2.Domain.Core.Notifications;
using Rumo.WebMetasV2.Domain.Events.CargoEvents;
using Rumo.WebMetasV2.Domain.Interfaces;
using Rumo.WebMetasV2.Domain.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Rumo.WebMetasV2.Domain.CommandHandlers
{
    public class CargoCommandHandler : CommandHandler,
        INotificationHandler<CadastrarCargoCommand>,
        INotificationHandler<AtualizarCargoCommand>,
        INotificationHandler<RemoverCargoCommand>
    {
        private readonly ICargoRepository _cargoRepository;
        private readonly IMediatorHandler Bus;

        public CargoCommandHandler(ICargoRepository cargoRepository,
                                    IUnitOfWork uow,
                                    IMediatorHandler bus,
                                    INotificationHandler<DomainNotification> notifications) :base(uow, bus, notifications)
        {
            _cargoRepository = cargoRepository;
            Bus = bus;
        }

        public Task Handle(CadastrarCargoCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            var cargo = new Cargo(Guid.NewGuid(), message.Nome, message.GrupoPoolId);

            _cargoRepository.Add(cargo);

            if (Commit())
            {
                Bus.RaiseEvent(new CargoRegisteredEvent(cargo.Id, cargo.Nome, cargo.GrupoPoolId));
                return Task.CompletedTask;
            }

            return Task.CompletedTask;
        }

        public Task Handle(AtualizarCargoCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            var cargo = new Cargo(message.Id, message.Nome, message.GrupoPoolId);

            _cargoRepository.Update(cargo);

            if (Commit())
            {
                Bus.RaiseEvent(new CargoUpdatedEvent(cargo.Id, cargo.Nome, cargo.GrupoPoolId));
                return Task.CompletedTask;
            }

            return Task.CompletedTask;
        }

        public Task Handle(RemoverCargoCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            _cargoRepository.Remove(message.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new CargoRemovedEvent(message.Id));
                return Task.CompletedTask;
            }

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _cargoRepository.Dispose();
        }
    }
}
