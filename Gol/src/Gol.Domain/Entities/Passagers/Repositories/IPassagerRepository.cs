using Gol.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gol.Domain.Entities.Passagers.Repositories
{
    public interface IPassagerRepository : IRepository<Passager>
    {
        IEnumerable<Passager> GetAllPassagersAirplanes(Guid idAirplane);
    }
}
