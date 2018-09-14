using MediatR;
using Rumo.WebMetasV2.Domain.Commands.GrupoPoolCommands;
using Rumo.WebMetasV2.Domain.Core.Bus;
using Rumo.WebMetasV2.Domain.Core.Notifications;
using Rumo.WebMetasV2.Domain.Events.GrupoPoolEvents;
using Rumo.WebMetasV2.Domain.Interfaces;
using Rumo.WebMetasV2.Domain.Models;
using System;

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

        public void Handle(CadastrarGrupoPoolCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var grupoPool = new GrupoPool(Guid.NewGuid(), message.Nome);

            _grupoPoolRepository.Add(grupoPool);

            if (Commit())
            {
                Bus.RaiseEvent(new GrupoPoolRegisteredEvent(grupoPool.Id, grupoPool.Nome));
            }
        }

        public void Handle(AtualizarGrupoPoolCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            var grupoPool = new GrupoPool(message.Id, message.Nome);

            _grupoPoolRepository.Update(grupoPool);

            if (Commit())
            {
                Bus.RaiseEvent(new GrupoPoolUpdatedEvent(grupoPool.Id, grupoPool.Nome));
            }
        }

        public void Handle(RemoverGrupoPoolCommand message)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return;
            }

            _grupoPoolRepository.Remove(message.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new GrupoPoolRemovedEvent(message.Id));
            }
        }

        public void Dispose()
        {
            _grupoPoolRepository.Dispose();
        }
    }
}
