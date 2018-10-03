using MediatR;
using Rumo.WebMetasV2.Domain.Commands.ColaboradorCommands;
using Rumo.WebMetasV2.Domain.Core.Bus;
using Rumo.WebMetasV2.Domain.Core.Notifications;
using Rumo.WebMetasV2.Domain.Events.ColaboradorEvents;
using Rumo.WebMetasV2.Domain.Interfaces;
using Rumo.WebMetasV2.Domain.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Rumo.WebMetasV2.Domain.CommandHandlers
{
    public class ColaboradorCommandHandler : CommandHandler,
        INotificationHandler<CadastrarColaboradorCommand>,
        INotificationHandler<AtualizarColaboradorCommand>,
        INotificationHandler<RemoverColaboradorCommand>
    {
        private readonly IColaboradorRepository _colaboradorRepository;
        private readonly IMediatorHandler Bus;

        public ColaboradorCommandHandler(IColaboradorRepository colaboradorRepository,
                                         IUnitOfWork uow,
                                         IMediatorHandler bus,
                                         INotificationHandler<DomainNotification> notifications) :base(uow, bus, notifications)
        {
            _colaboradorRepository = colaboradorRepository;
            Bus = bus;
        }

        public Task Handle(CadastrarColaboradorCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            var colaborador = new Colaborador(Guid.NewGuid(), message.Login, message.Nome, message.CargoId, message.CPF, message.DependenciaId, 
                                             message.PerfilId, message.Email, message.UnidadeId, message.SuperiorImediatoId, message.CadastroIncompleto, message.Ativo);

            _colaboradorRepository.Add(colaborador);

            if (Commit())
            {
                Bus.RaiseEvent(new ColaboradorRegisteredEvent(colaborador.Id, colaborador.Login, colaborador.Nome, colaborador.CargoId, colaborador.CPF, 
                                                              colaborador.DependenciaId, colaborador.PerfilId, colaborador.Email, colaborador.UnidadeId, 
                                                              colaborador.SuperiorImediatoId, colaborador.CadastroIncompleto, colaborador.Ativo));
                return Task.CompletedTask;
            }

            return Task.CompletedTask;
        }

        public Task Handle(AtualizarColaboradorCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            var colaborador = new Colaborador(message.Id, message.Login, message.Nome, message.CargoId, message.CPF, message.DependenciaId,
                                             message.PerfilId, message.Email, message.UnidadeId, message.SuperiorImediatoId, message.CadastroIncompleto, message.Ativo);

            _colaboradorRepository.Update(colaborador);

            if (Commit())
            {
                Bus.RaiseEvent(new ColaboradorUpdatedEvent(colaborador.Id, colaborador.Login, colaborador.Nome, colaborador.CargoId, colaborador.CPF,
                                                           colaborador.DependenciaId, colaborador.PerfilId, colaborador.Email, colaborador.UnidadeId,
                                                           colaborador.SuperiorImediatoId, colaborador.CadastroIncompleto, colaborador.Ativo));
                return Task.CompletedTask;
            }

            return Task.CompletedTask;
        }

        public Task Handle(RemoverColaboradorCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            _colaboradorRepository.Remove(message.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new ColaboradorRemovedEvent(message.Id));
                return Task.CompletedTask;
            }

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _colaboradorRepository.Dispose();
        }
    }
}
