using MediatR;
using Rumo.WebMetasV2.Domain.Commands.FluxoAprovacaoCommands;
using Rumo.WebMetasV2.Domain.Core.Bus;
using Rumo.WebMetasV2.Domain.Core.Notifications;
using Rumo.WebMetasV2.Domain.Events.FluxoAprovacaoEvents;
using Rumo.WebMetasV2.Domain.Interfaces;
using Rumo.WebMetasV2.Domain.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Rumo.WebMetasV2.Domain.CommandHandlers
{
    public class FluxoAprovacaoCommandHandler : CommandHandler,
        INotificationHandler<CadastrarFluxoAprovacaoCommand>,
        INotificationHandler<AtualizarFluxoAprovacaoCommand>,
        INotificationHandler<RemoverFluxoAprovacaoCommand>
    {
        private readonly IFluxoAprovacaoRepository _fluxoAprovacaoRepository;
        private readonly IMediatorHandler Bus;

        public FluxoAprovacaoCommandHandler(IFluxoAprovacaoRepository fluxoAprovacaoRepository,
                                            IUnitOfWork uow,
                                            IMediatorHandler bus,
                                            INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _fluxoAprovacaoRepository = fluxoAprovacaoRepository;
            Bus = bus;
        }

        public Task Handle(CadastrarFluxoAprovacaoCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            var fluxoAprovacao = new FluxoAprovacao(Guid.NewGuid(), message.Entidade);

            _fluxoAprovacaoRepository.Add(fluxoAprovacao);

            if (Commit())
            {
                Bus.RaiseEvent(new FluxoAprovacaoRegisteredEvent(fluxoAprovacao.Id, fluxoAprovacao.Entidade));
                return Task.CompletedTask;
            }

            return Task.CompletedTask;
        }

        public Task Handle(AtualizarFluxoAprovacaoCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            var fluxoAprovacao = new FluxoAprovacao(message.Id, message.Entidade);

            _fluxoAprovacaoRepository.Update(fluxoAprovacao);

            if (Commit())
            {
                Bus.RaiseEvent(new FluxoAprovacaoUpdatedEvent(fluxoAprovacao.Id, fluxoAprovacao.Entidade));
                return Task.CompletedTask;
            }

            return Task.CompletedTask;
        }

        public Task Handle(RemoverFluxoAprovacaoCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            _fluxoAprovacaoRepository.Remove(message.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new FluxoAprovacaoRemovedEvent(message.Id));
                return Task.CompletedTask;
            }

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _fluxoAprovacaoRepository.Dispose();
        }
    }
}
