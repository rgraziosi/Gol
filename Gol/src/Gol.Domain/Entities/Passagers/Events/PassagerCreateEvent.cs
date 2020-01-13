using System;
using System.Collections.Generic;
using System.Text;

namespace Gol.Domain.Entities.Passagers.Events
{
    public class PassagerCreateEvent : PassagerClassEvent
    {
        public PassagerCreateEvent(Passager passager)
        {
            Passager = passager;
            AggregateId = Passager.Id;
        }
    }
}
