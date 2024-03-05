using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Escambo.Application.InputModels;
using Escambo.Application.ViewModels;

namespace Escambo.Application.Services.Interfaces
{
    public interface IAvaliacaoService
    {
        
        public List<AvaliacaoViewModel> GetAll();
        public AvaliacaoViewModel? GetById(int id);
        public int Create(AvaliacaoInputModel avaliacao);
        public void Update(int id, AvaliacaoInputModel avaliacao);
        public void Delete(int id);
    }
}