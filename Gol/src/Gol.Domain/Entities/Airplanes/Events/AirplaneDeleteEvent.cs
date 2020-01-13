using System;
using System.Collections.Generic;
using System.Text;

namespace Gol.Domain.Entities.Airplanes.Events
{
    public class AirplaneDeleteEvent : AirplaneClassEvent
    {
        public AirplaneDeleteEvent(Guid id)
        {
            Id = id;
            AggregateId = Id;
        }
    }
}
