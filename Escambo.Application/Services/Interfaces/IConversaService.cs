using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Escambo.Application.InputModels;
using Escambo.Application.ViewModels;

namespace Escambo.Application.Services.Interfaces
{
    public interface IConversaService
    {
        
        public List<ConversaViewModel> GetAll();
        public ConversaViewModel? GetById(int id);
        public int Create(ConversaInputModel conversa);
        public void Update(int id, ConversaInputModel conversa);
        public void Delete(int id);
    }
}