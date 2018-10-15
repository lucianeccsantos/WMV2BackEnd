using MediatR;
using Rumo.WebMetasV2.Domain.Commands.IndicadorCommands;
using Rumo.WebMetasV2.Domain.Core.Bus;
using Rumo.WebMetasV2.Domain.Core.Notifications;
using Rumo.WebMetasV2.Domain.Events.IndicadorEvents;
using Rumo.WebMetasV2.Domain.Interfaces;
using Rumo.WebMetasV2.Domain.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Rumo.WebMetasV2.Domain.CommandHandlers
{
    public class IndicadorCommandHandler : CommandHandler,
        INotificationHandler<CadastrarIndicadorCommand>,
        INotificationHandler<AtualizarIndicadorCommand>,
        INotificationHandler<RemoverIndicadorCommand>
    {
        private readonly IIndicadorRepository _indicadorRepository;
        private readonly IMediatorHandler Bus;

        public IndicadorCommandHandler(IIndicadorRepository indicadorRepository,
                                       IUnitOfWork uow,
                                       IMediatorHandler bus,
                                       INotificationHandler<DomainNotification> notifications) :base(uow, bus, notifications)
        {
            _indicadorRepository = indicadorRepository;
            Bus = bus;
        }

        public Task Handle(CadastrarIndicadorCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            var indicador = new Indicador(message.Id, message.Nome, message.DirecaoIndicador, message.TipoIndicador, message.MesInicio, message.MesFim,
                                          message.Descricao, message.FormulaCalculo, message.Periodicidade, message.ColaboradorId);

            _indicadorRepository.Add(indicador);

            if (Commit())
            {
                Bus.RaiseEvent(new IndicadorRegisteredEvent(indicador.Id, indicador.Nome, indicador.DirecaoIndicador, indicador.TipoIndicador,
                                                            indicador.MesInicio, indicador.MesFim, indicador.Descricao, indicador.FormulaCalculo, 
                                                            indicador.Periodicidade, indicador.ColaboradorId));
                return Task.CompletedTask;
            }

            return Task.CompletedTask;
        }

        public Task Handle(AtualizarIndicadorCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            var indicador = new Indicador(message.Id, message.Nome, message.DirecaoIndicador, message.TipoIndicador, message.MesInicio, message.MesFim,
                                          message.Descricao, message.FormulaCalculo, message.Periodicidade, message.ColaboradorId);

            _indicadorRepository.Update(indicador);

            if (Commit())
            {
                Bus.RaiseEvent(new IndicadorUpdatedEvent(indicador.Id, indicador.Nome, indicador.DirecaoIndicador, indicador.TipoIndicador,
                                                         indicador.MesInicio, indicador.MesFim, indicador.Descricao, indicador.FormulaCalculo,
                                                            indicador.Periodicidade, indicador.ColaboradorId));
                return Task.CompletedTask;
            }

            return Task.CompletedTask;
        }

        public Task Handle(RemoverIndicadorCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.CompletedTask;
            }

            _indicadorRepository.Remove(message.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new IndicadorRemovedEvent(message.Id));
                return Task.CompletedTask;
            }

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _indicadorRepository.Dispose();
        }
    }
}
