using Gol.Domain.Core.Bus;
using Gol.Domain.Core.Notifications;
using Gol.Domain.Interface;
using FluentValidation.Results;
using System.Collections.Generic;

namespace Gol.Domain.CommandHandlers
{
    public abstract class CommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IBus _bus;
        private readonly IDomainNotificationHandler<DomainNotification> _notifications;

        protected CommandHandler(IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notifications)
        {
            _uow = uow;
            _bus = bus;
            _notifications = notifications;
        }

        protected void NotificarValidacoesErro(List<string> validationErros)
        {
            foreach (var error in validationErros)
            {
                _bus.RaiseEvent(new DomainNotification("Erro de propriedade", error));
            }
        }

        protected bool Commit()
        {
            // Se já houver erro não continua pro commit
            if (_notifications.HasNotifications()) return false;

            var commandResponse = _uow.Commit();
            if (commandResponse.Success) return true;

            _bus.RaiseEvent(new DomainNotification("Commit", "Erro ao salvar dados no banco"));
            return false;
        }
    }
}