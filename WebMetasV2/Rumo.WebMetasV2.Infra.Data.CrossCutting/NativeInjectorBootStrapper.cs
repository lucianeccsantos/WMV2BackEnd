using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Rumo.WebMetasV2.Application.Interfaces;
using Rumo.WebMetasV2.Application.Service;
using Rumo.WebMetasV2.Domain.CommandHandlers;
using Rumo.WebMetasV2.Domain.Commands.GrupoPoolCommands;
using Rumo.WebMetasV2.Domain.Commands.PerfilCommands;
using Rumo.WebMetasV2.Domain.Commands.UnidadeCommands;
using Rumo.WebMetasV2.Domain.Core.Bus;
using Rumo.WebMetasV2.Domain.Core.Events;
using Rumo.WebMetasV2.Domain.Core.Notifications;
using Rumo.WebMetasV2.Domain.EventHandlers;
using Rumo.WebMetasV2.Domain.Events;
using Rumo.WebMetasV2.Domain.Events.GrupoPoolEvents;
using Rumo.WebMetasV2.Domain.Events.PerfilEvents;
using Rumo.WebMetasV2.Domain.Interfaces;
using Rumo.WebMetasV2.Infra.Data.Context;
using Rumo.WebMetasV2.Infra.Data.EventSourcing;
using Rumo.WebMetasV2.Infra.Data.Repository;
using Rumo.WebMetasV2.Infra.Data.UoW;

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
            services.AddScoped<IGrupoPoolAppService, GrupoPoolAppService>();
            services.AddScoped<IUnidadeAppService, UnidadeAppService>();
            services.AddScoped<IPerfilAppService, PerfilAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            #region Events - GrupoPool
            services.AddScoped<INotificationHandler<GrupoPoolRegisteredEvent>, GrupoPoolEventHandler>();
            services.AddScoped<INotificationHandler<GrupoPoolUpdatedEvent>, GrupoPoolEventHandler>();
            services.AddScoped<INotificationHandler<GrupoPoolRemovedEvent>, GrupoPoolEventHandler>();
            #endregion

            #region Events - Unidade
            services.AddScoped<INotificationHandler<UnidadeRegisteredEvent>, UnidadeEventHandler>();
            services.AddScoped<INotificationHandler<UnidadeUpdatedEvent>, UnidadeEventHandler>();
            services.AddScoped<INotificationHandler<UnidadeRemovedEvent>, UnidadeEventHandler>();
            #endregion

            #region Events - Perfil
            services.AddScoped<INotificationHandler<PerfilRegisteredEvent>, PerfilEventHandler>();
            services.AddScoped<INotificationHandler<PerfilUpdatedEvents>, PerfilEventHandler>();
            services.AddScoped<INotificationHandler<PerfilRemovedEvents>, PerfilEventHandler>();
            #endregion

            // Domain - Commands
            #region Commands - GrupoPool
            services.AddScoped<INotificationHandler<CadastrarGrupoPoolCommand>, GrupoPoolCommandHandler>();
            services.AddScoped<INotificationHandler<AtualizarGrupoPoolCommand>, GrupoPoolCommandHandler>();
            services.AddScoped<INotificationHandler<RemoverGrupoPoolCommand>, GrupoPoolCommandHandler>();
            #endregion

            #region Commands - Unidade
            services.AddScoped<INotificationHandler<CadastrarUnidadeCommand>, UnidadeCommandHandler>();
            services.AddScoped<INotificationHandler<AtualizarUnidadeCommand>, UnidadeCommandHandler>();
            services.AddScoped<INotificationHandler<RemoverUnidadeCommand>, UnidadeCommandHandler>();
            #endregion

            #region Commands - Perfil
            services.AddScoped<INotificationHandler<CadastrarPerfilCommand>, PerfilCommandHandler>();
            services.AddScoped<INotificationHandler<AtualizarPerfilCommand>, PerfilCommandHandler>();
            services.AddScoped<INotificationHandler<RemoverPerfilCommand>, PerfilCommandHandler>();
            #endregion

            
            // Infra - Data
            services.AddScoped<IGrupoPoolRepository, GrupoPoolRepository>();
            services.AddScoped<IUnidadeRepository, UnidadeRepository>();
            services.AddScoped<IPerfilRepository, PerfilRepository>();


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
