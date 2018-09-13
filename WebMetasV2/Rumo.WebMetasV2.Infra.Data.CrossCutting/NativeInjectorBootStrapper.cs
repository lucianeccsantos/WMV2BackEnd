using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Rumo.WebMetasV2.Domain.Core.Bus;
using Rumo.WebMetasV2.Domain.Core.Events;
using Rumo.WebMetasV2.Domain.Core.Notifications;
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
            //services.AddSingleton(Mapper.Configuration);
            //services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
            //services.AddScoped<ICityAppService, CityAppService>();
            


            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            //services.AddScoped<INotificationHandler<LegalPersonRegisteredEvent>, LegalPersonEventHandler>();
            //services.AddScoped<INotificationHandler<LegalPersonUpdatedEvent>, LegalPersonEventHandler>();
            //services.AddScoped<INotificationHandler<LegalPersonRemovedEvent>, LegalPersonEventHandler>();

            // Domain - Commands
            //services.AddScoped<INotificationHandler<RegisterNewLegalPersonCommand>, LegalPersonCommandHandler>();
            //services.AddScoped<INotificationHandler<UpdateLegalPersonCommand>, LegalPersonCommandHandler>();
            //services.AddScoped<INotificationHandler<RemoveLegalPersonCommand>, LegalPersonCommandHandler>();

            // Infra - Data
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
