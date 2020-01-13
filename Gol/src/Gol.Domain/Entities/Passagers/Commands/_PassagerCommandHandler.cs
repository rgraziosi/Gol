using Gol.Domain.CommandHandlers;
using Gol.Domain.Core.Bus;
using Gol.Domain.Core.Events.Interfaces;
using Gol.Domain.Core.Notifications;
using Gol.Domain.Entities.Passagers.Events;
using Gol.Domain.Entities.Passagers.Repositories;
using Gol.Domain.Interface;
using Gol.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gol.Domain.Entities.Passagers.Commands
{
    public class PassagerCommandHandler : CommandHandler,
         IHandler<PassagerCreateCommand>,
         IHandler<PassagerCreateWithAirplaneCommand>,
         IHandler<PassagerReadCommand>,
         IHandler<PassagerUpdateCommand>,
         IHandler<PassagerDeleteCommand>
    {
        private readonly IPassagerRepository _passagerRepository;
        private readonly IBus _bus;

        public PassagerCommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notifications, IPassagerRepository PassagerRepository)
            : base(uow, bus, notifications)
        {
            _passagerRepository = PassagerRepository;
            _bus = bus;
        }

        public async void Handle(PassagerCreateCommand message)
        {
            Passager passager = message.Passager;

            if (!PassagerValid(passager)) return;

            // Validação de negocio
            // Nome Igual X

            // Persistencia
            passager.SetDateInsert();
            passager.SetAirplane(null);
            _passagerRepository.Add(passager);

            if (Commit())
            {
                //_bus.RaiseEvent(new PassagerCreateEvent(message.Passager));
            }
        }

        public async void Handle(PassagerCreateWithAirplaneCommand message)
        {
            Passager passager = message.Passager;

            if (!PassagerValid(passager)) return;

            // Validação de negocio
            // Nome Igual X

            // Persistencia
            passager.SetDateInsert();
            _passagerRepository.Add(passager);

            if (Commit())
            {
                //_bus.RaiseEvent(new PassagerCreateEvent(message.Passager));
            }
        }

        //Eu devia criar o handler de query pra respeita o CQS q eu fiz e fazer isso lá ? sim, mas sem tempo irmão 
        public void Handle(PassagerReadCommand message)
        {
            Passager passager = message.Passager;

            if (!PassagerValid(passager)) return;

            // Validação de negocio
            // Nome Igual X

            // Persistencia
            _passagerRepository.GetAllPassagersAirplanes((Guid)passager.IdAirplane);

            if (Commit())
            {
                //_bus.RaiseEvent(new PassagerReadEvent(message.Passager));
            }
        }

        public void Handle(PassagerUpdateCommand message)
        {
            if (! PassagerExists(message.Passager.Id, message.MessageType)) return;

            // Validação de negocio
            // Nome Igual X

            Passager passager = message.Passager;

            if (! PassagerValid(passager)) return;

            passager.SetDateUpdate();
             _passagerRepository.Update(passager);

            if (Commit())
            {
                //_bus.RaiseEvent(new PassagerUpdateEvent(message.Passager));
            }
        }

        public void Handle(PassagerDeleteCommand message)
        {
            if (! PassagerExists(message.Id, message.MessageType)) return;

            _passagerRepository.Remove(message.Id);

            if (Commit())
            {
                //_bus.RaiseEvent(new PassagerDeleteEvent(message.Id));
            }
        }

        #region [ Methods privates]

        private bool PassagerValid(Passager passager)
        {
            if (passager.Valido()) return true;

            NotificarValidacoesErro(passager.ValidationErro);
            return false;
        }

        private bool PassagerExists(Guid Id, string messageType)
        {
            Passager passager = _passagerRepository.GetById(Id);

            if (passager != null) return true;

            _bus.RaiseEvent(new DomainNotification(messageType, Messages.MSG_PASSAGER_NOT_FOUND));
            return false;
        }

        #endregion [ Methods privates]
    }
}
