using Gol.Domain.CommandHandlers;
using Gol.Domain.Core.Bus;
using Gol.Domain.Core.Events.Interfaces;
using Gol.Domain.Core.Notifications;
using Gol.Domain.Entities.Airplanes.Events;
using Gol.Domain.Entities.Airplanes.Repositories;
using Gol.Domain.Entities.Passagers.Repositories;
using Gol.Domain.Interface;
using Gol.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gol.Domain.Entities.Airplanes.Commands
{
    public class AirplaneCommandHandler : CommandHandler,
         IHandler<AirplaneCreateCommand>,
         //IHandler<AirplaneReadCommand>,
         IHandler<AirplaneUpdateCommand>,
         IHandler<AirplaneDeleteCommand>
    {
        private readonly IAirplaneRepository _airplaneRepository;
        private readonly IPassagerRepository _passagerRepository;
        private readonly IBus _bus;

        //Verificar os events depois para gravação de log.
        //Verificar o UoW depois de implementar as transaction do dapper
        public AirplaneCommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notifications, IAirplaneRepository airplaneRepository, IPassagerRepository passagerRepository)
            : base(uow, bus, notifications)
        {
            _passagerRepository = passagerRepository;
            _airplaneRepository = airplaneRepository;
            _bus = bus;
        }

        public void Handle(AirplaneCreateCommand message)
        {
            Airplane airplane = message.Airplane;

            if (!AirplaneValid(airplane)) return;

            // Validação de negocio
            // Nome Igual X

            // Persistencia
            airplane.SetDateInsert();
            _airplaneRepository.Add(airplane);

            if (Commit())
            {
               // _bus.RaiseEvent(new AirplaneCreateEvent(message.Airplane));
            }
        }
        
        public void Handle(AirplaneUpdateCommand message)
        {
            if (! AirplaneExists(message.Airplane.Id, message.MessageType)) return;

            // Validação de negocio
            // Nome Igual X

            Airplane airplane = message.Airplane;

            if (!AirplaneValid(airplane)) return;

            airplane.SetDateUpdate();
            _airplaneRepository.Update(airplane);

            if (Commit())
            {
               // _bus.RaiseEvent(new AirplaneUpdateEvent(message.Airplane));
            }
        }

        //ia precisar fazer um middleware pra exception -- refatorar depois
        public void Handle(AirplaneDeleteCommand message)
        {
            if (!AirplaneExists(message.Id, message.MessageType)) return;

            var passagers = _passagerRepository.GetAllPassagersAirplanes(message.Id);

            if (passagers.ToList().Count > 0) {
                _bus.RaiseEvent(new DomainNotification("Erro", "The Airplane has Passagers"));
                return;
            };


            _airplaneRepository.Remove(message.Id);


            if (Commit())
            {
               // _bus.RaiseEvent(new AirplaneDeleteEvent(message.Id));
            }
        }

        #region [ Methods privates]

        private bool AirplaneValid(Airplane airplane)
        {
            if (airplane.Valido()) return true;

            NotificarValidacoesErro(airplane.ValidationErro);
            return false;
        }

        private bool  AirplaneExists(Guid Id, string messageType)
        {
            Airplane airplane= _airplaneRepository.GetById(Id);

            if (airplane != null) return true;

            _bus.RaiseEvent(new DomainNotification(messageType, Messages.MSG_AIRPLANE_NOT_FOUND));
            return false;
        }

        #endregion [ Methods privates]
    }
}
