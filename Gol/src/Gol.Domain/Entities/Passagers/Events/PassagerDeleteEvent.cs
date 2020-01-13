using System;
using System.Collections.Generic;
using System.Text;

namespace Gol.Domain.Entities.Passagers.Events
{
    public class PassagerDeleteEvent : PassagerClassEvent
    {
        public PassagerDeleteEvent(Guid id)
        {
            Id = id;
            AggregateId = Id;
        }
    }
}
