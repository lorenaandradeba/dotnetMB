using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Escambo.Application.InputModels;
using Escambo.Application.ViewModels;

namespace Escambo.Application.Services.Interfaces
{
    public interface IMensagemService
    {
        
        public List<MensagemViewModel> GetAll();
        public MensagemViewModel? GetById(int id);
        public int Create(MensagemInputModel mensagem);
        public void Update(int id, MensagemInputModel mensagem);
        public void Delete(int id);
    }
}