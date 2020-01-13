using Gol.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gol.Domain.Entities.Airplanes.Events
{
    public abstract class AirplaneClassEvent : Event
    {
        public Guid Id { get; protected set; }

        public Airplane Airplane { get; protected set; }
    }
}
