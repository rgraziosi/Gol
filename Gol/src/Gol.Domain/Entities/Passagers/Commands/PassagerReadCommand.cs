using System;
using System.Collections.Generic;
using System.Text;

namespace Gol.Domain.Entities.Passagers.Commands
{
    public class PassagerReadCommand : PassagerClassCommand
    {
        public PassagerReadCommand(Guid id)
        {
            Id = id;
            AggregateId = Id;
        }
    }
}
