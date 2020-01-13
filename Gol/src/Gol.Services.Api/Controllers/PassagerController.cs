using AutoMapper;
using Gol.Domain.Core.Bus;
using Gol.Domain.Core.Notifications;
using Gol.Domain.Entities.Passagers.Commands;
using Gol.Domain.Entities.Passagers.Repositories;
using Gol.Services.Api.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Gol.Services.Api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class PassagerController : BaseController
    {
        private readonly IBus _bus;
        private readonly IPassagerRepository _passagerRepository;
        private readonly IMapper _mapper;

        public PassagerController(IDomainNotificationHandler<DomainNotification> notifications,
                                      IBus bus,
                                      IPassagerRepository passagerRepository,
                                      IMapper mapper) : base(notifications, bus)
        {
            _passagerRepository = passagerRepository;
            _mapper = mapper;
            _bus = bus;
        }

        [HttpGet]
        [Route("GetAllPassager")]
        public IEnumerable<PassagerViewModel> Get()
        {
            return _mapper.Map<IEnumerable<PassagerViewModel>>(_passagerRepository.GetAll());
        }

        [HttpGet]
        [Route("GetAllByAirplane/{id:guid}")]
        public IEnumerable<PassagerViewModel> GetPassagersWithByAirplane(Guid id)
        {
           return _mapper.Map<IEnumerable<PassagerViewModel>>(_passagerRepository.GetAllPassagersAirplanes(id));
        }

        [HttpGet]
        [Route("FindPassager/{id:guid}")]
        public PassagerViewModel Get(Guid id)
        {
            return _mapper.Map<PassagerViewModel>(_passagerRepository.GetById(id));
        }

        [HttpPost]
        [Route("InsertPassager")]
        public IActionResult Post([FromBody] PassagerViewModel passagerViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotificarErroModelInvalida();
                return Response();
            }

            //Erro meu, liga não, depois eu refatoro, funciona kkkk
            if(passagerViewModel.IdAirplane == null || passagerViewModel.IdAirplane == Guid.Empty)
            {
                var createPassager = _mapper.Map<PassagerCreateCommand>(passagerViewModel);
                _bus.SendCommand(createPassager);
                return Response(createPassager);
            }
            else
            {
                var createPassagerWithAirplane = _mapper.Map<PassagerCreateWithAirplaneCommand>(passagerViewModel);
                _bus.SendCommand(createPassagerWithAirplane);
                return Response(createPassagerWithAirplane);
            }
        }

        [HttpPut]
        [Route("UpdatePassager")]
        public IActionResult Put([FromBody] PassagerViewModel passagerViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotificarErroModelInvalida();
                return Response();
            }

            var updatePassager = _mapper.Map<PassagerUpdateCommand>(passagerViewModel);
            _bus.SendCommand(updatePassager);

            return Response(updatePassager);
        }

        [HttpDelete]
        [Route("Passager/{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            _bus.SendCommand(new PassagerDeleteCommand(id));
            return Response();
        }

    }
}