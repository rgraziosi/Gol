using AutoMapper;
using Gol.Domain.Entities.Airplanes;
using Gol.Domain.Entities.Airplanes.Commands;
using Gol.Domain.Entities.Passagers;
using Gol.Domain.Entities.Passagers.Commands;
using Gol.Services.Api.ViewModel;
using System;

namespace Gol.Services.Api.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<AirplaneViewModel, AirplaneCreateCommand>()
               .ConstructUsing(c => new AirplaneCreateCommand(new Airplane(c.Name, c.Type)));

            CreateMap<AirplaneViewModel, AirplaneUpdateCommand>()
               .ConstructUsing(c => new AirplaneUpdateCommand(new Airplane(c.Id, c.Name, c.Type)));

            CreateMap<AirplaneViewModel, AirplaneDeleteCommand>()
                .ConstructUsing(c => new AirplaneDeleteCommand(c.Id));


            CreateMap<PassagerViewModel, PassagerCreateCommand>()
               .ConstructUsing(c => new PassagerCreateCommand(Passager.PassagerFactory.Passager(c.Id, c.Name, c.Type, c.Seat)));

            CreateMap<PassagerViewModel, PassagerCreateWithAirplaneCommand>()
               .ConstructUsing(c => new PassagerCreateWithAirplaneCommand(Passager.PassagerFactory.PassagerWithAirplane(c.Id, c.Name, c.Type, c.Seat, c.IdAirplane)));

            CreateMap<PassagerViewModel, PassagerUpdateCommand>()
               .ConstructUsing(c => new PassagerUpdateCommand(Passager.PassagerFactory.PassagerWithAirplane(c.Id, c.Name, c.Type, c.Seat, c.IdAirplane)));

            CreateMap<PassagerViewModel, PassagerDeleteCommand>()
                .ConstructUsing(c => new PassagerDeleteCommand(c.Id));
        }
    }
}