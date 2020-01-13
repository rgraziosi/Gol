using System;
using System.Collections.Generic;
using System.Text;

namespace Gol.Domain.Entities.Airplanes.Events
{
    public class AirplaneReadEvent : AirplaneClassEvent
    {
        public AirplaneReadEvent(Airplane airplane)
        {
            Airplane = airplane;
            AggregateId = airplane.Id;
        }
    }
}
