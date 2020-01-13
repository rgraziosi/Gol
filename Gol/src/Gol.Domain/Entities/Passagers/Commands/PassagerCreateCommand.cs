using System;
using System.Collections.Generic;
using System.Text;

namespace Gol.Domain.Entities.Passagers.Commands
{
    public class PassagerCreateCommand : PassagerClassCommand
    {
        public PassagerCreateCommand(Passager passager)
        {
            Passager = passager;
        }
    }
}
