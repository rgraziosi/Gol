using System;
using System.Collections.Generic;
using System.Text;

namespace Gol.Domain.Entities.Airplanes.Events
{
    public class AirplaneCreateEvent : AirplaneClassEvent
    {
        public AirplaneCreateEvent(Airplane airplane)
        {
            Airplane = airplane;
            AggregateId = airplane.Id;
        }
    }
}
