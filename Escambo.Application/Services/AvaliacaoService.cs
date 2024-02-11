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
    public class AvaliacaoService : IAvaliacaoService
    {
         
        private readonly EscamboContext _context;
        public AvaliacaoService(EscamboContext context)
        {
            _context = context;
        }
        public int Create(AvaliacaoInputModel avaliacao)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<AvaliacaoViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public AvaliacaoViewModel? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, AvaliacaoInputModel avaliacao)
        {
            throw new NotImplementedException();
        }
    }
}