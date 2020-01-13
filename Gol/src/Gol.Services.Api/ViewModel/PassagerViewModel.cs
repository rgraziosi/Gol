using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gol.Services.Api.ViewModel
{
    public class PassagerViewModel
    {
        public PassagerViewModel()
        {
            Id = Guid.NewGuid();
            Airplane = new AirplaneViewModel();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Seat { get; set; }
        public Guid? IdAirplane { get; set; }
        public AirplaneViewModel Airplane { get; set; }
    }
}
