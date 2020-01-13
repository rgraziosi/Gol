using System;
using System.Collections.Generic;
using System.Text;

namespace Gol.Domain.Entities.Airplanes.Commands
{
    public class AirplaneReadCommand : AirplaneClassCommand
    {
        public AirplaneReadCommand(Guid id)
        {
            Id = id;
            AggregateId = Id;
        }
    }
}
