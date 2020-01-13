using AutoMapper;
using Gol.Domain.Core.Bus;
using Gol.Domain.Core.Notifications;
using Gol.Domain.Entities.Airplanes.Commands;
using Gol.Domain.Entities.Airplanes.Repositories;
using Gol.Services.Api.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Gol.Services.Api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AirplaneController : BaseController
    {
        private readonly IBus _bus;
        private readonly IAirplaneRepository _airplaneRepository;
        private readonly IMapper _mapper;

        public AirplaneController(IDomainNotificationHandler<DomainNotification> notifications,
                                      IBus bus,
                                      IAirplaneRepository airplaneRepository,
                                      IMapper mapper) : base(notifications, bus)
        {
            _airplaneRepository = airplaneRepository;
            _mapper = mapper;
            _bus = bus;
        }

        [HttpGet]
        [Route("GetAllAirplane")]
        public IEnumerable<AirplaneViewModel> Get()
        {
            return _mapper.Map<IEnumerable<AirplaneViewModel>>(_airplaneRepository.GetAll());
        }

        [HttpGet]
        [Route("FindAirplane/{id:guid}")]
        public AirplaneViewModel Get(Guid id)
        {
            return _mapper.Map<AirplaneViewModel>(_airplaneRepository.GetById(id));
        }

        [HttpPost]
        [Route("InsertAirplane")]
        public IActionResult Post([FromBody] AirplaneViewModel airplaneViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotificarErroModelInvalida();
                return Response();
            }

            var createAirplane = _mapper.Map<AirplaneCreateCommand>(airplaneViewModel);
            _bus.SendCommand(createAirplane);

            return Response(createAirplane);
        }

        [HttpPut]
        [Route("UpdateAirplane")]
        public IActionResult Put([FromBody] AirplaneViewModel airplaneViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotificarErroModelInvalida();
                return Response();
            }

            var updateAirplane = _mapper.Map<AirplaneUpdateCommand>(airplaneViewModel);
            _bus.SendCommand(updateAirplane);

            return Response(updateAirplane);
        }

        [HttpDelete]
        [Route("Airplane/{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            _bus.SendCommand(new AirplaneDeleteCommand(id));
            return Response();
        }

    }
}