using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gol.Services.Api.ViewModel
{
    public class AirplaneViewModel
    {
        public AirplaneViewModel()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
