using AutoMapper;
using Gol.Domain.Entities;
using Gol.Domain.Entities.Airplanes;
using Gol.Domain.Entities.Passagers;
using Gol.Services.Api.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gol.Services.Api.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Airplane, AirplaneViewModel>();
            CreateMap<Passager, PassagerViewModel>();
        }
    }
}