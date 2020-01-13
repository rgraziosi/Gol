
using Gol.Domain.Core.Bus;
using Gol.Domain.Core.Events.Interfaces;
using Gol.Domain.Core.Notifications;
using Gol.Domain.Entities.Airplanes.Commands;
using Gol.Domain.Entities.Airplanes.Events;
using Gol.Domain.Entities.Airplanes.Repositories;
using Gol.Domain.Entities.Passagers.Commands;
using Gol.Domain.Entities.Passagers.Events;
using Gol.Domain.Entities.Passagers.Repositories;
using Gol.Domain.Interface;
using Gol.Infra.CrossCutting.Bus;
using Gol.Infra.Data.Repository;
using Gol.Infra.Data.UoW;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Gol.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // Application
            //services.AddSingleton(Mapper.Configuration);
            //services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));

            // Domain - Commands

            //Airplane
            services.AddScoped<IHandler<AirplaneCreateCommand>, AirplaneCommandHandler>();
            //services.AddScoped<IHandler<AirplaneReadCommand>, AirplaneCommandHandler>();
            services.AddScoped<IHandler<AirplaneUpdateCommand>, AirplaneCommandHandler>();
            services.AddScoped<IHandler<AirplaneDeleteCommand>, AirplaneCommandHandler>();

            //Passager
            services.AddScoped<IHandler<PassagerCreateCommand>, PassagerCommandHandler>();
            services.AddScoped<IHandler<PassagerCreateWithAirplaneCommand>, PassagerCommandHandler>();
            services.AddScoped<IHandler<PassagerReadCommand>, PassagerCommandHandler>();
            services.AddScoped<IHandler<PassagerUpdateCommand>, PassagerCommandHandler>();
            services.AddScoped<IHandler<PassagerDeleteCommand>, PassagerCommandHandler>();

            // Domain - Eventos
            services.AddScoped<IDomainNotificationHandler<DomainNotification>, DomainNotificationHandler>();

            //Airplane
            services.AddScoped<IHandler<AirplaneCreateEvent>, AirplaneEventHandler>();
            services.AddScoped<IHandler<AirplaneReadEvent>, AirplaneEventHandler>();
            services.AddScoped<IHandler<AirplaneUpdateEvent>, AirplaneEventHandler>();
            services.AddScoped<IHandler<AirplaneDeleteEvent>, AirplaneEventHandler>();

            //Passager
            services.AddScoped<IHandler<PassagerCreateEvent>, PassagerEventHandler>();
            services.AddScoped<IHandler<PassagerReadEvent>, PassagerEventHandler>();
            services.AddScoped<IHandler<PassagerUpdateEvent>, PassagerEventHandler>();
            services.AddScoped<IHandler<PassagerDeleteEvent>, PassagerEventHandler>();

            // Infra - Data
            services.AddScoped<IAirplaneRepository, AirplaneRepository>();
            services.AddScoped<IPassagerRepository, PassagerRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Infra - Bus
            services.AddScoped<IBus, InMemoryBus>();
        }
    }
}