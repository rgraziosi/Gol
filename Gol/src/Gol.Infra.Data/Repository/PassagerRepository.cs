using Dapper;
using System.Linq;
using System.Collections.Generic;
using Gol.Domain.Entities.Passagers;
using Gol.Domain.Entities.Passagers.Repositories;
using System;
using System.Threading.Tasks;

namespace Gol.Infra.Data.Repository
{
    public class PassagerRepository : Repository<Passager>, IPassagerRepository
    {
        public PassagerRepository() : base("Passager")
        {
            
        }

        public IEnumerable<Passager> GetAllPassagersAirplanes(Guid idAirplane)
        {
            using (var connection = CreateConnection())
            {
                return connection.Query<Passager>($"SELECT * FROM Passager WHERE idAirplane = '{idAirplane}'");
            }
        }
    }
}