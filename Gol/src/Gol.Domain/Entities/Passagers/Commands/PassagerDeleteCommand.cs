using System;
using System.Collections.Generic;
using System.Text;

namespace Gol.Domain.Entities.Passagers.Commands
{
    public class PassagerDeleteCommand : PassagerClassCommand
    {
        public PassagerDeleteCommand(Guid id)
        {
            Id = id;
            AggregateId = Id;
        }
    }
}
