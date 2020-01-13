using AutoMapper;
using AvivatecParty.Application.ViewModels;
using AvivatecParty.Domain.Entities;
using AvivatecParty.Domain.Entities.Participantes.Commands;
using System;

namespace AvivatecParty.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ParticipanteViewModel, RegistrarParticipanteCommand>()
               .ConstructUsing(c => new RegistrarParticipanteCommand(Participante.ParticipanteFactory.NovoParticipanteCompleto(Guid.NewGuid(), c.Nome, c.Email, c.Login, c.Senha, c.MelhorDiaHora, c.LocalId, c.Organizador)));

            CreateMap<ParticipanteViewModel, AtualizarParticipanteCommand>()
               .ConstructUsing(c => new AtualizarParticipanteCommand(Participante.ParticipanteFactory.NovoParticipanteCompleto(c.Id, c.Nome, c.Email, c.Login, c.Senha, c.MelhorDiaHora, c.LocalId, c.Organizador)));

            CreateMap<ParticipanteViewModel, RemoverParticipanteCommand>()
                .ConstructUsing(c => new RemoverParticipanteCommand(c.Id));
        }
    }
}