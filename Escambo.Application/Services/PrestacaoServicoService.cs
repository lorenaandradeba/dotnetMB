
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Escambo.Application.InputModels;
using Escambo.Application.Services.Interfaces;
using Escambo.Application.ViewModels;
using Escambo.Infra.Context;

namespace Escambo.Application.Services
{
    public class PrestacaoServicoService : IPrestacaoServicoService
    {
         
        private readonly EscamboContext _context;
        public PrestacaoServicoService(EscamboContext context)
        {
            _context = context;
        }
        public int Create(PrestacaoServicoInputModel prestacao)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<PrestacaoServicoViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public PrestacaoServicoViewModel? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, PrestacaoServicoInputModel prestacao)
        {
            throw new NotImplementedException();
        }
    }
}