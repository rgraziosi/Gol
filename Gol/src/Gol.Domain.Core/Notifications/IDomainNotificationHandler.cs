using Gol.Domain.Core.Events;
using Gol.Domain.Core.Events.Interfaces;
using System.Collections.Generic;

namespace Gol.Domain.Core.Notifications
{
    public interface IDomainNotificationHandler<T> : IHandler<T> where T : Message
    {
        bool HasNotifications();

        List<T> GetNotifications();
    }
}