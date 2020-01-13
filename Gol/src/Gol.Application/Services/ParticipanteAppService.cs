using AutoMapper;
using AvivatecParty.Application.Interfaces;
using AvivatecParty.Application.ViewModels;
using AvivatecParty.Domain.Core.Bus;
using AvivatecParty.Domain.Entities;
using AvivatecParty.Domain.Entities.Participantes.Commands;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AvivatecParty.Application.Services
{
    public class ParticipanteAppService : IParticipanteAppService
    {
        private readonly IBus _bus;
        private readonly IMapper _mapper;
        private readonly IParticipanteRepository _participanteRepository;

        public ParticipanteAppService(IBus bus,
                        IMapper mapper,
                        IParticipanteRepository participanteRepository)
        {
            _bus = bus;
            _mapper = mapper;
            _participanteRepository = participanteRepository;
        }

        public void Add(ParticipanteViewModel participanteViewModel)
        {
            var registroCommand = _mapper.Map<RegistrarParticipanteCommand>(participanteViewModel);
            _bus.SendCommand(registroCommand);
        }

        public void Dispose()
        {
            _participanteRepository.Dispose();
        }

        public IEnumerable<ParticipanteViewModel> GetAll()
        {
            var locais = _mapper.Map<IEnumerable<LocalViewModel>>(_participanteRepository.GetAllLocais());
            return _mapper.Map<IEnumerable<ParticipanteViewModel>>(_participanteRepository.GetAll());

        }

        public IEnumerable<LocalViewModel> GetAllLocais()
        {
            return _mapper.Map<IEnumerable<LocalViewModel>>(_participanteRepository.GetAllLocais());
        }

        public ParticipanteViewModel GetById(Guid id)
        {
            return _mapper.Map<ParticipanteViewModel>(_participanteRepository.GetById(id));
        }

        public void Remove(Guid id)
        {
            _bus.SendCommand(new RemoverParticipanteCommand(id));
        }

        public void Update(ParticipanteViewModel participanteViewModel)
        {
            var atualizarParticipanteCommand = _mapper.Map<AtualizarParticipanteCommand>(participanteViewModel);
            _bus.SendCommand(atualizarParticipanteCommand);
        }
    }
}