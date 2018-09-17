using MediatR;
using Rumo.WebMetasV2.Domain.Commands.GrupoPoolCommands;
using Rumo.WebMetasV2.Domain.Core.Bus;
using Rumo.WebMetasV2.Domain.Core.Notifications;
using Rumo.WebMetasV2.Domain.Events.GrupoPoolEvents;
using Rumo.WebMetasV2.Domain.Interfaces;
using Rumo.WebMetasV2.Domain.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Rumo.WebMetasV2.Domain.CommandHandlers
{
    public class GrupoPoolCommandHandler : CommandHandler,
        INotificationHandler<CadastrarGrupoPoolCommand>,
        INotificationHandler<AtualizarGrupoPoolCommand>,
        INotificationHandler<RemoverGrupoPoolCommand>
    {
        private readonly IGrupoPoolRepository _grupoPoolRepository;
        private readonly IMediatorHandler Bus;

        public GrupoPoolCommandHandler(IGrupoPoolRepository grupoPoolRepository,
                                       IUnitOfWork uow,
                                       IMediatorHandler bus,
                                       INotificationHandler<DomainNotification> notifications) :base(uow, bus, notifications)
        {
            _grupoPoolRepository = grupoPoolRepository;
            Bus = bus;
        }

        public Task Handle(CadastrarGrupoPoolCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            var grupoPool = new GrupoPool(Guid.NewGuid(), message.Nome);

            _grupoPoolRepository.Add(grupoPool);

            if (Commit())
            {
                Bus.RaiseEvent(new GrupoPoolRegisteredEvent(grupoPool.Id, grupoPool.Nome));
                return Task.CompletedTask;
            }
            return Task.CompletedTask;
        }

        public Task Handle(AtualizarGrupoPoolCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            var grupoPool = new GrupoPool(message.Id, message.Nome);

            _grupoPoolRepository.Update(grupoPool);

            if (Commit())
            {
                Bus.RaiseEvent(new GrupoPoolUpdatedEvent(grupoPool.Id, grupoPool.Nome));
                return Task.CompletedTask;
            }

            return Task.CompletedTask;
        }

        public Task Handle(RemoverGrupoPoolCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            _grupoPoolRepository.Remove(message.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new GrupoPoolRemovedEvent(message.Id));
                return Task.CompletedTask;
            }
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _grupoPoolRepository.Dispose();
        }
    }
}
