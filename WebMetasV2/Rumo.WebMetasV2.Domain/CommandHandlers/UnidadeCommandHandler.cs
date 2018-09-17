using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Rumo.WebMetasV2.Domain.Commands.UnidadeCommands;
using Rumo.WebMetasV2.Domain.Core.Bus;
using Rumo.WebMetasV2.Domain.Core.Notifications;
using Rumo.WebMetasV2.Domain.Events;
using Rumo.WebMetasV2.Domain.Interfaces;
using Rumo.WebMetasV2.Domain.Models;

namespace Rumo.WebMetasV2.Domain.CommandHandlers
{
    public class UnidadeCommandHandler : CommandHandler,
                                         INotificationHandler<CadastrarUnidadeCommand>,
                                         INotificationHandler<AtualizarUnidadeCommand>,
                                         INotificationHandler<RemoverUnidadeCommand>
    {

        private readonly IUnidadeRepository _unidadeRepository;
        private readonly IMediatorHandler Bus;

        public UnidadeCommandHandler(IUnidadeRepository unidadeRepository,
                                     IUnitOfWork uow, 
                                     IMediatorHandler bus, 
                                     INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _unidadeRepository = unidadeRepository;
            Bus = bus;
        }

        
        public Task Handle(CadastrarUnidadeCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            var unidade = new Unidade(Guid.NewGuid(), message.Nome);
            _unidadeRepository.Add(unidade);

            if (Commit())
            {
                Bus.RaiseEvent(new UnidadeRegisteredEvent(unidade.Id, unidade.Nome));
                return Task.CompletedTask;
            }
            return Task.CompletedTask;
        }

        public Task Handle(AtualizarUnidadeCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            var unidade = new Unidade(message.Id, message.Nome);

            _unidadeRepository.Update(unidade);

            if (Commit())
            {
                Bus.RaiseEvent(new UnidadeRegisteredEvent(unidade.Id, unidade.Nome));
                return Task.CompletedTask;
            }


            return Task.CompletedTask;
        }

        public Task Handle(RemoverUnidadeCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            _unidadeRepository.Remove(message.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new UnidadeRegisteredEvent(message.Id, message.Nome));
                return Task.CompletedTask;
            }
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _unidadeRepository.Dispose();
        }
    }
}
