using System;
using System.Collections.Generic;

namespace AvivatecParty.Application.ViewModels
{
    public class LocalViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        // Teste
        public List<LocalViewModel> ListarLocais()
        {
            var categoriasList = new List<LocalViewModel>()
            {
                new LocalViewModel(){ Id = new Guid("ac381ba8-c187-482c-a5cb-899ad7176137"), Nome = "Na Empresa"},
                new LocalViewModel(){ Id = new Guid("1bbfa7e9-5a1f-4cef-b209-58954303dfc3"), Nome = "Fora da Empresa"},
                new LocalViewModel(){ Id = new Guid("d443f7c6-04e5-4f48-8fe0-9e6726b4fdb0"), Nome = "Tanto Faz"}
            };

            return categoriasList;
        }
    }
}