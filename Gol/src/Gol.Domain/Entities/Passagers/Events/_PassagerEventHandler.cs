using Gol.Domain.Core.Events.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gol.Domain.Entities.Passagers.Events
{
    public class PassagerEventHandler :
                IHandler<PassagerCreateEvent>,
                IHandler<PassagerReadEvent>,
                IHandler<PassagerUpdateEvent>,
                IHandler<PassagerDeleteEvent>
    {
        public void Handle(PassagerCreateEvent message)
        {
            // Log ou enviar email
        }

        public void Handle(PassagerReadEvent message)
        {
            // Log ou enviar email
        }

        public void Handle(PassagerUpdateEvent message)
        {
            // Log ou enviar email
        }
        public void Handle(PassagerDeleteEvent message)
        {
            // Log ou enviar email
        }
    }
}
