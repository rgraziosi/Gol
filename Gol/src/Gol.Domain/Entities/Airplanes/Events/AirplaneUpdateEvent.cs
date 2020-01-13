using System;
using System.Collections.Generic;
using System.Text;

namespace Gol.Domain.Entities.Airplanes.Events
{
    public class AirplaneUpdateEvent : AirplaneClassEvent
    {
        public AirplaneUpdateEvent(Airplane airplane)
        {
            Airplane = airplane;
            AggregateId = airplane.Id;
        }
    }
}
