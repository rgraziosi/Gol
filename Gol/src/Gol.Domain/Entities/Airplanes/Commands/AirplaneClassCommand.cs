using Gol.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gol.Domain.Entities.Airplanes.Commands
{

    public abstract class AirplaneClassCommand : Command
    {
        public Guid Id { get; protected set; }

        public Airplane Airplane { get; protected set; }
    }
}
