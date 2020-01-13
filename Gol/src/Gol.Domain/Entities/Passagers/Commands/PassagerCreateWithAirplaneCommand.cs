using System;
using System.Collections.Generic;
using System.Text;

namespace Gol.Domain.Entities.Passagers.Commands
{
    public class PassagerCreateWithAirplaneCommand : PassagerClassCommand
    {
        public PassagerCreateWithAirplaneCommand(Passager passager)
        {
            Passager = passager;
        }
    }
}
