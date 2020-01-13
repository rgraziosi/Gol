using Gol.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gol.Domain.Entities.Passagers.Commands
{
    public abstract class PassagerClassCommand : Command
    {
        public Guid Id { get; protected set; }

        public Passager Passager { get; protected set; }
    }
}
