using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Escambo.Application.InputModels;
using Escambo.Application.ViewModels;

namespace Escambo.Application.Services.Interfaces
{
    public interface IPrestacaoServicoService
    {
        
        public List<PrestacaoServicoViewModel> GetAll();
        public PrestacaoServicoViewModel? GetById(int id);
        public int Create(PrestacaoServicoInputModel prestacao);
        public void Update(int id, PrestacaoServicoInputModel prestacao);
        public void Delete(int id);
    }
}