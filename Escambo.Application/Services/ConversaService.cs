
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Escambo.Application.InputModels;
using Escambo.Application.Services.Interfaces;
using Escambo.Application.ViewModels;
using Escambo.Dommain.Model;
using Escambo.Infra.Context;

namespace Escambo.Application.Services
{
    public class ConversaService : IConversaService
    {
         
        private readonly EscamboContext _context;
        private readonly IMensagemService _MensagemService;
        public ConversaService(EscamboContext context)
        {
            _context = context;
        }
        public int Create(ConversaInputModel conversa)
        {
            //  public int ConversasIdMensagem { get; set; }
            // public int UsuariosIdUsuario { get; set; }
            // public Conversa? Conversa { get; set; }
            // public Usuario? Usuario { get; set; }
            
            //    var id = _context.ConversasHasUsuarios.Count() + 1;
            //    var _chat = new ConversasHasUsuarios{
            //      ConversasIdMensagem = id,
            //      UsuariosIdUsuario = conversa.UsuariosIdUsuario

            //    };
            //    _context.ConversasHasUsuarios.AddRange();
            //    return _chat.ConversaId;
             throw new NotImplementedException();
        }
        public void Update(int id, ConversaInputModel conversa)
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

       
    }
}