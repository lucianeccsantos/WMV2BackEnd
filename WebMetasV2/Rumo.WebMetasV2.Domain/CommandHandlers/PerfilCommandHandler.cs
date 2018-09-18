using MediatR;
using Rumo.WebMetasV2.Domain.Commands.PerfilCommands;
using Rumo.WebMetasV2.Domain.Core.Bus;
using Rumo.WebMetasV2.Domain.Core.Notifications;
using Rumo.WebMetasV2.Domain.Events.PerfilEvents;
using Rumo.WebMetasV2.Domain.Interfaces;
using Rumo.WebMetasV2.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rumo.WebMetasV2.Domain.CommandHandlers
{
    public class PerfilCommandHandler : CommandHandler,
                                        INotificationHandler<CadastrarPerfilCommand>,
                                        INotificationHandler<AtualizarPerfilCommand>,
                                        INotificationHandler<RemoverPerfilCommand>
    {
        private readonly IPerfilRepository _perfilRepository;
        private readonly IMediatorHandler Bus;

        public PerfilCommandHandler(IPerfilRepository perfilRepository,
                                    IUnitOfWork uow,
                                    IMediatorHandler bus,
                                    INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _perfilRepository = perfilRepository;
            Bus = bus;
        }

        public Task Handle(CadastrarPerfilCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            var perfil = new Perfil(Guid.NewGuid(), message.Nome, message.Situacao);
            _perfilRepository.Add(perfil);

            if (Commit())
            {
                Bus.RaiseEvent(new PerfilRegisteredEvent(perfil.Id, perfil.Nome, perfil.Situacao));
                return Task.CompletedTask;
            }

            return Task.CompletedTask;

        }

        public Task Handle(AtualizarPerfilCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            var perfil = new Perfil(message.Id, message.Nome, message.Situacao);
            _perfilRepository.Update(perfil);

            if (Commit())
            {
                Bus.RaiseEvent(new PerfilUpdatedEvents(perfil.Id, perfil.Nome, perfil.Situacao));
                return Task.CompletedTask;
            }
            return Task.CompletedTask;
        }

        public Task Handle(RemoverPerfilCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            _perfilRepository.Remove(message.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new PerfilRemovedEvents(message.Id));
                return Task.CompletedTask;
            }

            return Task.CompletedTask;
        }
    }
}
