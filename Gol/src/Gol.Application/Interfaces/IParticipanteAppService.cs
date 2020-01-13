using AvivatecParty.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace AvivatecParty.Application.Interfaces
{
    public interface IParticipanteAppService : IDisposable
    {
        // commands
        void Add(ParticipanteViewModel obj);

        void Update(ParticipanteViewModel obj);

        void Remove(Guid id);

        // querys
        ParticipanteViewModel GetById(Guid id);

        IEnumerable<ParticipanteViewModel> GetAll();

        IEnumerable<LocalViewModel> GetAllLocais();
    }
}