using System;
using System.Collections.Generic;
using System.Text;

namespace Gol.Domain.Entities.Passagers.Events
{
    public class PassagerUpdateEvent : PassagerClassEvent
    {
        public PassagerUpdateEvent(Passager passager)
        {
            Passager = passager;
            AggregateId = Passager.Id;
        }
    }
}
