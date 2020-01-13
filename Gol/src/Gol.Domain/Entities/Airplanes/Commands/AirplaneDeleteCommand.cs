using System;
using System.Collections.Generic;
using System.Text;

namespace Gol.Domain.Entities.Airplanes.Commands
{
    public class AirplaneDeleteCommand : AirplaneClassCommand
    {
        public AirplaneDeleteCommand(Guid id)
        {
            Id = id;
            AggregateId = Id;
        }
    }
}
