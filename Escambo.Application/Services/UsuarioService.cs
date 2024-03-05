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
    public class UsuarioService :  IUsuarioService
    {
         
        private readonly EscamboContext _context;
        public UsuarioService(EscamboContext context)
        {
            _context = context;
        }
        // private readonly IUsuarioService _usuarioService;
        // public UsuarioService(EscamboContext context,  IUsuarioService usuarioService): base(context)
        // {
        //     _usuarioService = usuarioService;
        // }
       public int Create(UsuarioInputModel usuarioInput)
        {
            var id = _context.Usuarios.Count() + 1;
            var novoUsuario = new Usuario
            {
                UsuarioId = id,
                Nome = usuarioInput.Nome,
                Email = usuarioInput.Email,
                Senha = usuarioInput.Senha,
                CPF = usuarioInput.CPF,
                RG = usuarioInput.RG,
                Nascimento = usuarioInput.Nascimento,
                Endereço = usuarioInput.Endereço,
                Status = usuarioInput.Status,
                Credito = usuarioInput.Credito,
                LinkLinkedln = usuarioInput.LinkLinkedln,
                Sobre = usuarioInput.Sobre
            };

            _context.Usuarios.Add(novoUsuario);

            _context.SaveChanges();

            return novoUsuario.UsuarioId;
        }

        public void Delete(int id)
        {
            var _usuario = _context.Usuarios.Find(id);
            if (_usuario == null)
                return;
            _context.Usuarios.Remove(_usuario);
             _context.SaveChanges();
        }

        public List<UsuarioViewModel> GetAll()
        {
            var usuarios = _context.Usuarios.Select(u => new UsuarioViewModel{
                UsuarioId = u.UsuarioId,
                Email = u.Email,
                Nome = u.Nome!,
                Senha = u.Senha,
                CPF = u.CPF,
                RG = u.RG,
                Nascimento = u.Nascimento,
                Endereço = u.Endereço,
                Status = u.Status,
                Credito = u.Credito,
                LinkLinkedln = u.LinkLinkedln,
                Sobre = u.Sobre,
                Anuncios = u.Anuncios.Select(a => new AnuncioViewModel
                {
                    AnuncioId = a.AnuncioId,
                    NomeServico = a.NomeServico,
                    Descricao = a.Descricao,
                    Creditos = a.Creditos,
                    Categoria = a.Categoria,
                    Tipo = a.Tipo,
                    UsuarioId = a.UsuarioId,
                    Usuario = new UsuarioViewModel{
                        UsuarioId = a.Usuario!.UsuarioId,
                        Nome = a.Usuario!.Nome!,
                    }

                }).ToList(),

            });
            return usuarios.ToList();
        }

        public UsuarioViewModel? GetById(int id)
        {
            var _usuarios = _context.Usuarios.Find(id);

            if (_usuarios == null)
                return null;

            return new UsuarioViewModel{
                UsuarioId = _usuarios.UsuarioId,
                Email = _usuarios.Email,
                Nome = _usuarios.Nome!,
                Senha = _usuarios.Senha,
                CPF = _usuarios.CPF,
                RG = _usuarios.RG,
                Nascimento = _usuarios.Nascimento,
                Endereço = _usuarios.Endereço,
                Status = _usuarios.Status,
                Credito = _usuarios.Credito,
                LinkLinkedln = _usuarios.LinkLinkedln,
                Sobre = _usuarios.Sobre,
                Anuncios = _usuarios.Anuncios.Select(a => new AnuncioViewModel
                {
                    AnuncioId = a.AnuncioId,

                }).ToList(),
               
                Conversas = _usuarios.ConversasHasUsuarios.Select(c => new ConversaViewModel
                {
                    ConversaId = c.ConversasIdMensagem,
                }).ToList()
            }; 

        }

        public void Update(int id, UsuarioInputModel usuarioInput)
        {
            var usuarioExistente =  _context.Usuarios.FirstOrDefault(u => u.UsuarioId == id);


            if (usuarioExistente == null)
            {
               return;
            }

            usuarioExistente.Nome = usuarioInput.Nome;
            usuarioExistente.Email = usuarioInput.Email;
            usuarioExistente.Senha = usuarioInput.Senha;
            usuarioExistente.CPF = usuarioInput.CPF;
            usuarioExistente.RG = usuarioInput.RG;
            usuarioExistente.Nascimento = usuarioInput.Nascimento;
            usuarioExistente.Endereço = usuarioInput.Endereço;
            usuarioExistente.Status = usuarioInput.Status;
            usuarioExistente.Credito = usuarioInput.Credito;
            usuarioExistente.LinkLinkedln = usuarioInput.LinkLinkedln;
            usuarioExistente.Sobre = usuarioInput.Sobre;

            _context.Usuarios.Update(usuarioExistente);
            _context.SaveChanges();
        }

    }
}