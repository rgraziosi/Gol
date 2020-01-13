using System;
using System.Collections.Generic;
using System.Text;

namespace Gol.Domain.Entities.Airplanes.Commands
{
    public class AirplaneUpdateCommand : AirplaneClassCommand
    {
        public AirplaneUpdateCommand(Airplane airplane)
        {
            Airplane = airplane;
        }
    }
}
