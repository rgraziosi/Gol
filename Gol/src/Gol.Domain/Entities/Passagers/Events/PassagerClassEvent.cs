using Gol.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gol.Domain.Entities.Passagers.Events
{
    public abstract class PassagerClassEvent : Event
    {
        public Guid Id { get; protected set; }

        public Passager Passager { get; protected set; }
    }
}
