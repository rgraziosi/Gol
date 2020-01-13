using System;

namespace AvivatecParty.Application.ViewModels
{
    public class ParticipanteViewModel
    {
        public ParticipanteViewModel()
        {
            Id = Guid.NewGuid();
            Local = new LocalViewModel();
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public DateTime MelhorDiaHora { get; set; }
        public bool Organizador { get; set; }

        public Guid LocalId { get; set; }
        public virtual LocalViewModel Local { get; set; }
    }
}