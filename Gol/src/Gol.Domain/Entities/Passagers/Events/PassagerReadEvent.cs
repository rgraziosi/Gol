using System;
using System.Collections.Generic;
using System.Text;

namespace Gol.Domain.Entities.Passagers.Events
{
    public class PassagerReadEvent : PassagerClassEvent
    {
        public PassagerReadEvent(Passager passager)
        {
            Passager = passager;
            AggregateId = Passager.Id;
        }
    }
}
