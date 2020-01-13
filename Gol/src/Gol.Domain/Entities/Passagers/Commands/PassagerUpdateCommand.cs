using System;
using System.Collections.Generic;
using System.Text;

namespace Gol.Domain.Entities.Passagers.Commands
{
    public class PassagerUpdateCommand : PassagerClassCommand
    {
        public PassagerUpdateCommand(Passager passager)
        {
            Passager = passager;
        }
    }
}
