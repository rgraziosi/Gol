using Gol.Domain.Core.Commands;
using Gol.Domain.Core.Events;

namespace Gol.Domain.Core.Bus
{
    public interface IBus
    {
        void SendCommand<T>(T theCommand) where T : Command;

        void RaiseEvent<T>(T theEvent) where T : Event;
    }
}