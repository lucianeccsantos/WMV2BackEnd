using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Rumo.WebMetasV2.Application.Interfaces;
using Rumo.WebMetasV2.Application.Service;
using Rumo.WebMetasV2.Domain.CommandHandlers;
using Rumo.WebMetasV2.Domain.Commands.AreaCommands;
using Rumo.WebMetasV2.Domain.Commands.EscopoCommands;
using Rumo.WebMetasV2.Domain.Commands.GrupoPoolCommands;
using Rumo.WebMetasV2.Domain.Commands.PerfilCommands;
using Rumo.WebMetasV2.Domain.Commands.UnidadeCommands;
using Rumo.WebMetasV2.Domain.Core.Bus;
using Rumo.WebMetasV2.Domain.Core.Events;
using Rumo.WebMetasV2.Domain.Core.Notifications;
using Rumo.WebMetasV2.Domain.EventHandlers;
using Rumo.WebMetasV2.Domain.Events.AreaEvents;
using Rumo.WebMetasV2.Domain.Events.EscopoEvents;
using Rumo.WebMetasV2.Domain.Events;
using Rumo.WebMetasV2.Domain.Events.GrupoPoolEvents;
using Rumo.WebMetasV2.Domain.Events.PerfilEvents;
using Rumo.WebMetasV2.Domain.Interfaces;
using Rumo.WebMetasV2.Infra.Data.Context;
using Rumo.WebMetasV2.Infra.Data.EventSourcing;
using Rumo.WebMetasV2.Infra.Data.Repository;
using Rumo.WebMetasV2.Infra.Data.UoW;
using Rumo.WebMetasV2.Domain.Events.IndicadorEvents;
using Rumo.WebMetasV2.Domain.Commands.IndicadorCommands;
using Rumo.WebMetasV2.Domain.Events.IndicadorEscopoAreaEvents;
using Rumo.WebMetasV2.Domain.Commands.IndicadorEscopoAreaCommands;
using Rumo.WebMetasV2.Domain.Events.CargoEvents;
using Rumo.WebMetasV2.Domain.Commands.CargoCommands;
using Rumo.WebMetasV2.Domain.Events.DependenciaEvents;
using Rumo.WebMetasV2.Domain.Commands.DependenciaCommands;
using Rumo.WebMetasV2.Domain.Events.ColaboradorEvents;
using Rumo.WebMetasV2.Domain.Commands.ColaboradorCommands;
using Rumo.WebMetasV2.Domain.Events.DiretoriaEvents;
using Rumo.WebMetasV2.Domain.Commands.DiretoriaCommands;

namespace Rumo.WebMetasV2.Infra.Data.CrossCutting
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        { 
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // ASP.NET Authorization Polices
            //services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>(); ;

            // Application
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
            services.AddScoped<IAreaAppService, AreaAppService>();
            services.AddScoped<ICargoAppService, CargoAppService>();
            services.AddScoped<IColaboradorAppService, ColaboradorAppService>();
            services.AddScoped<IDependenciaAppService, DependenciaAppService>();
            services.AddScoped<IDiretoriaAppService, DiretoriaAppService>();
            services.AddScoped<IEscopoAppService, EscopoAppService>();
            services.AddScoped<IIndicadorAppService, IndicadorAppService>();
            services.AddScoped<IGrupoPoolAppService, GrupoPoolAppService>();
            services.AddScoped<IPerfilAppService, PerfilAppService>();
            services.AddScoped<IUnidadeAppService, UnidadeAppService>();
            

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            #region Events - Area
            services.AddScoped<INotificationHandler<AreaRegisteredEvent>, AreaEventHandler>();
            services.AddScoped<INotificationHandler<AreaUpdatedEvent>, AreaEventHandler>();
            services.AddScoped<INotificationHandler<AreaRemovedEvent>, AreaEventHandler>();
            #endregion

            #region Events - Cargo
            services.AddScoped<INotificationHandler<CargoRegisteredEvent>, CargoEventHandler>();
            services.AddScoped<INotificationHandler<CargoUpdatedEvent>, CargoEventHandler>();
            services.AddScoped<INotificationHandler<CargoRemovedEvent>, CargoEventHandler>();
            #endregion 

            #region Events - Colaborador
            services.AddScoped<INotificationHandler<ColaboradorRegisteredEvent>, ColaboradorEventHandler>();
            services.AddScoped<INotificationHandler<ColaboradorUpdatedEvent>, ColaboradorEventHandler>();
            services.AddScoped<INotificationHandler<ColaboradorRemovedEvent>, ColaboradorEventHandler>();
            #endregion 

            #region Events - Dependencia
            services.AddScoped<INotificationHandler<DependenciaRegisteredEvent>, DependenciaEventHandler>();
            services.AddScoped<INotificationHandler<DependenciaUpdatedEvent>, DependenciaEventHandler>();
            services.AddScoped<INotificationHandler<DependenciaRemovedEvent>, DependenciaEventHandler>();
            #endregion 

            #region Events - Diretoria
            services.AddScoped<INotificationHandler<DiretoriaRegisteredEvent>, DiretoriaEventHandler>();
            services.AddScoped<INotificationHandler<DiretoriaUpdatedEvent>, DiretoriaEventHandler>();
            services.AddScoped<INotificationHandler<DiretoriaRemovedEvent>, DiretoriaEventHandler>();
            #endregion 

            #region Events - Escopo
            services.AddScoped<INotificationHandler<EscopoRegisteredEvent>, EscopoEventHandler>();
            services.AddScoped<INotificationHandler<EscopoUpdatedEvent>, EscopoEventHandler>();
            services.AddScoped<INotificationHandler<EscopoRemovedEvent>, EscopoEventHandler>();
            #endregion 

            #region Events - GrupoPool
            services.AddScoped<INotificationHandler<GrupoPoolRegisteredEvent>, GrupoPoolEventHandler>();
            services.AddScoped<INotificationHandler<GrupoPoolUpdatedEvent>, GrupoPoolEventHandler>();
            services.AddScoped<INotificationHandler<GrupoPoolRemovedEvent>, GrupoPoolEventHandler>();
            #endregion

            #region Events - IndicadorEscopoArea
            services.AddScoped<INotificationHandler<IndicadorEscopoAreaRegisteredEvent>, IndicadorEscopoAreaEventHandler>();
            services.AddScoped<INotificationHandler<IndicadorEscopoAreaUpdatedEvent>, IndicadorEscopoAreaEventHandler>();
            services.AddScoped<INotificationHandler<IndicadorEscopoAreaRemovedEvent>, IndicadorEscopoAreaEventHandler>();
            #endregion

            #region Events - Perfil
            services.AddScoped<INotificationHandler<PerfilRegisteredEvent>, PerfilEventHandler>();
            services.AddScoped<INotificationHandler<PerfilUpdatedEvents>, PerfilEventHandler>();
            services.AddScoped<INotificationHandler<PerfilRemovedEvents>, PerfilEventHandler>();
            #endregion

            #region Events - Unidade
            services.AddScoped<INotificationHandler<IndicadorRegisteredEvent>, IndicadorEventHandler>();
            services.AddScoped<INotificationHandler<IndicadorUpdatedEvent>, IndicadorEventHandler>();
            services.AddScoped<INotificationHandler<IndicadorRemovedEvent>, IndicadorEventHandler>();

            services.AddScoped<INotificationHandler<UnidadeRegisteredEvent>, UnidadeEventHandler>();
            services.AddScoped<INotificationHandler<UnidadeUpdatedEvent>, UnidadeEventHandler>();
            services.AddScoped<INotificationHandler<UnidadeRemovedEvent>, UnidadeEventHandler>();
            #endregion



            // Domain - Commands
            #region Commands - Area
            services.AddScoped<INotificationHandler<CadastrarAreaCommand>, AreaCommandHandler>();
            services.AddScoped<INotificationHandler<AtualizarAreaCommand>, AreaCommandHandler>();
            services.AddScoped<INotificationHandler<RemoverAreaCommand>, AreaCommandHandler>();
            #endregion

            #region Commands - Cargo
            services.AddScoped<INotificationHandler<CadastrarCargoCommand>, CargoCommandHandler>();
            services.AddScoped<INotificationHandler<AtualizarCargoCommand>, CargoCommandHandler>();
            services.AddScoped<INotificationHandler<RemoverCargoCommand>, CargoCommandHandler>();
            #endregion

            #region Commands - Colaborador
            services.AddScoped<INotificationHandler<CadastrarColaboradorCommand>, ColaboradorCommandHandler>();
            services.AddScoped<INotificationHandler<AtualizarColaboradorCommand>, ColaboradorCommandHandler>();
            services.AddScoped<INotificationHandler<RemoverColaboradorCommand>, ColaboradorCommandHandler>();
            #endregion

            #region Commands - Dependencia
            services.AddScoped<INotificationHandler<CadastrarDependenciaCommand>, DependenciaCommandHandler>();
            services.AddScoped<INotificationHandler<AtualizarDependenciaCommand>, DependenciaCommandHandler>();
            services.AddScoped<INotificationHandler<RemoverDependenciaCommand>, DependenciaCommandHandler>();
            #endregion

            #region Commands - Diretoria
            services.AddScoped<INotificationHandler<CadastrarDiretoriaCommand>, DiretoriaCommandHandler>();
            services.AddScoped<INotificationHandler<AtualizarDiretoriaCommand>, DiretoriaCommandHandler>();
            services.AddScoped<INotificationHandler<RemoverDiretoriaCommand>, DiretoriaCommandHandler>();
            #endregion

            #region Commands - Escopo
            services.AddScoped<INotificationHandler<CadastrarEscopoCommand>, EscopoCommandHandler>();
            services.AddScoped<INotificationHandler<AtualizarEscopoCommand>, EscopoCommandHandler>();
            services.AddScoped<INotificationHandler<RemoverEscopoCommand>, EscopoCommandHandler>();
            #endregion

            #region Commands - GrupoPool
            services.AddScoped<INotificationHandler<CadastrarGrupoPoolCommand>, GrupoPoolCommandHandler>();
            services.AddScoped<INotificationHandler<AtualizarGrupoPoolCommand>, GrupoPoolCommandHandler>();
            services.AddScoped<INotificationHandler<RemoverGrupoPoolCommand>, GrupoPoolCommandHandler>();
            #endregion

            #region Commands - Perfil
            services.AddScoped<INotificationHandler<CadastrarPerfilCommand>, PerfilCommandHandler>();
            services.AddScoped<INotificationHandler<AtualizarPerfilCommand>, PerfilCommandHandler>();
            services.AddScoped<INotificationHandler<RemoverPerfilCommand>, PerfilCommandHandler>();
            #endregion

            #region Commands - Indicador
            services.AddScoped<INotificationHandler<CadastrarIndicadorCommand>, IndicadorCommandHandler>();
            services.AddScoped<INotificationHandler<AtualizarIndicadorCommand>, IndicadorCommandHandler>();
            services.AddScoped<INotificationHandler<RemoverIndicadorCommand>, IndicadorCommandHandler>();
            #endregion

            #region Commands - IndicadorEscopoArea
            services.AddScoped<INotificationHandler<CadastrarIndicadorEscopoAreaCommand>, IndicadorEscopoAreaCommandHandler>();
            services.AddScoped<INotificationHandler<AtualizarIndicadorEscopoAreaCommand>, IndicadorEscopoAreaCommandHandler>();
            services.AddScoped<INotificationHandler<RemoverIndicadorEscopoAreaCommand>, IndicadorEscopoAreaCommandHandler>();
            #endregion

            #region Commands - Unidade
            services.AddScoped<INotificationHandler<CadastrarUnidadeCommand>, UnidadeCommandHandler>();
            services.AddScoped<INotificationHandler<AtualizarUnidadeCommand>, UnidadeCommandHandler>();
            services.AddScoped<INotificationHandler<RemoverUnidadeCommand>, UnidadeCommandHandler>();
            #endregion

            

            
            // Infra - Data
            services.AddScoped<IAreaRepository, AreaRepository>();
            services.AddScoped<ICargoRepository, CargoRepository>();
            services.AddScoped<IColaboradorRepository, ColaboradorRepository>();
            services.AddScoped<IDependenciaRepository, DependenciaRepository>();
            services.AddScoped<IDiretoriaRepository, DiretoriaRepository>();
            services.AddScoped<IEscopoRepository, EscopoRepository>();
            services.AddScoped<IGrupoPoolRepository, GrupoPoolRepository>();
            services.AddScoped<IPerfilRepository, PerfilRepository>();
            services.AddScoped<IIndicadorRepository, IndicadorRepository>();
            services.AddScoped<IIndicadorEscopoAreaRepository, IndicadorEscopoAreaRepository>();
            services.AddScoped<IUnidadeRepository, UnidadeRepository>();
            

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<WebMetasContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            //services.AddScoped<EventStoreSQLContext>();

            // Infra - Identity Services
            //services.AddTransient<IEmailSender, AuthEmailMessageSender>();
            //services.AddTransient<ISmsSender, AuthSMSMessageSender>();

            // Infra - Identity
            //services.AddScoped<IUser, AspNetUser>();
        }
    }
}
