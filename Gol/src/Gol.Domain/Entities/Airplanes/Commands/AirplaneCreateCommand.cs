using System;
using System.Collections.Generic;
using System.Text;

namespace Gol.Domain.Entities.Airplanes.Commands
{
    public class AirplaneCreateCommand : AirplaneClassCommand
    {
        public AirplaneCreateCommand(Airplane airplane)
        {
            Airplane = airplane;
        }
    }
}
