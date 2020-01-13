using Gol.Domain.Core.Events.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gol.Domain.Entities.Airplanes.Events
{
    public class AirplaneEventHandler :
            IHandler<AirplaneCreateEvent>,
            IHandler<AirplaneReadEvent>,
            IHandler<AirplaneUpdateEvent>,
            IHandler<AirplaneDeleteEvent>
    {
        public void Handle(AirplaneCreateEvent message)
        {
            // Log ou enviar email
        }

        public void Handle(AirplaneReadEvent message)
        {
            // Log ou enviar email
        }

        public void Handle(AirplaneUpdateEvent message)
        {
            // Log ou enviar email
        }
        public void Handle(AirplaneDeleteEvent message)
        {
            // Log ou enviar email
        }
    }
}
