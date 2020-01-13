using Dapper;
using System.Linq;
using System.Collections.Generic;
using Gol.Domain.Entities.Airplanes;
using Gol.Domain.Entities.Airplanes.Repositories;

namespace Gol.Infra.Data.Repository
{
    public class AirplaneRepository : Repository<Airplane>, IAirplaneRepository
    {
        public AirplaneRepository() : base("Airplane")
        {
            
        }

    }
}