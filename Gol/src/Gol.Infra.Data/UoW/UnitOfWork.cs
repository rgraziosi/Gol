using Gol.Domain.Core.Commands;
using Gol.Domain.Interface;

namespace Gol.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {

        public UnitOfWork()
        {
        }

        //Implementar em um segundo momento os transaction pro Dapper
        public CommandResponse Commit()
        {
            return new CommandResponse(true);
        }

        public void Dispose()
        {
            //Dispose();
        }
    }
}