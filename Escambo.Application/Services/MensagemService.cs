
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
    public class MensagemService : IMensagemService
    {

        private readonly EscamboContext _context;
        public MensagemService(EscamboContext context)
        {
            _context = context;
        }
        public int Create(MensagemInputModel mensagem)
        {
            var id = _context.Mensagens.Count() + 1;
            var _mensagem = new Mensagem
            {
                MensagemId = id,
                Texto = mensagem.Texto,
                DataEnvio = DateTime.Now.Date,
                HoraEnvio = DateTime.Now,
                ConversaId = mensagem.ConversasIdMensagem,
                UsuariosIdUsuario = mensagem.UsuariosIdUsuario

            };
            _context.Mensagens.Add(_mensagem);
            _context.SaveChanges();
            return _mensagem.MensagemId;
        }

        public void Delete(int id)
        {
            var mensagem = _context.Mensagens.Find(id);
            if (mensagem == null)
                return;
            _context.Mensagens.Remove(mensagem);
            _context.SaveChanges();
        }

        public List<MensagemViewModel> GetAll()
        {
            var _mensagens = _context.Mensagens.Select(x => new MensagemViewModel
            {
                ConversaId = x.ConversaId,
                MensagemId = x.MensagemId,
                UsuariosIdUsuario = x.UsuariosIdUsuario,
                DataEnvio = x.DataEnvio,
                HoraEnvio = x.HoraEnvio,
                Texto = x.Texto,
                Usuario = new UsuarioViewModel{
                    Nome = x.Usuario.Nome,
                }
            });

            return _mensagens.ToList();
        }

        public MensagemViewModel? GetById(int id)
        {
            var mensagem = _context.Mensagens.Find(id);
            if (mensagem == null)
                return null;

            return new MensagemViewModel
            {
                ConversaId = mensagem.ConversaId,
                Texto = mensagem.Texto,
                UsuariosIdUsuario = mensagem.UsuariosIdUsuario,
                HoraEnvio = mensagem.HoraEnvio,
                DataEnvio = mensagem.DataEnvio,
            };
        }

        public void Update(int id, MensagemInputModel mensagem)
        {
            var _mensagem = _context.Mensagens.Find(id);
            if (_mensagem == null)
                return;
            _mensagem.Texto = mensagem.Texto;
            _mensagem.Updated = DateTime.Now;
            _context.Mensagens.Update(_mensagem);
            _context.SaveChanges();
        }
    }
}