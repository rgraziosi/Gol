using Gol.Domain.Core.Commands;
using System;

namespace Gol.Domain.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        CommandResponse Commit();
    }
}