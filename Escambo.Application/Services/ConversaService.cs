
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
    public class ConversaService : IConversaService
    {
         
        private readonly EscamboContext _context;
        public ConversaService(EscamboContext context)
        {
            _context = context;
        }
        public int Create(ConversaInputModel conversa)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<ConversaViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public ConversaViewModel? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, ConversaInputModel conversa)
        {
            throw new NotImplementedException();
        }
    }
}