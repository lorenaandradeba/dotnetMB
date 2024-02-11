
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
    public class MensagemService : IMensagemService
    {
         
        private readonly EscamboContext _context;
        public MensagemService(EscamboContext context)
        {
            _context = context;
        }
        public int Create(MensagemInputModel mensagem)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<MensagemViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public MensagemViewModel? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, MensagemInputModel mensagem)
        {
            throw new NotImplementedException();
        }
    }
}