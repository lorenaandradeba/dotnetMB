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
            var novoUsuario = new Usuario
            {
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
            throw new NotImplementedException();
        }

        public List<UsuarioViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public UsuarioViewModel? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, UsuarioInputModel usuario)
        {
            throw new NotImplementedException();
        }

        // public void Update(int id, UsuarioInputModel usuarioInput)
        // {
        //     var usuarioExistente = _usuarioRepository.GetById(id);

        //     if (usuarioExistente == null)
        //     {
        //         throw new UsuarioNotFoundException($"Usuário com ID {id} não encontrado.");
        //     }

        //     usuarioExistente.Nome = usuarioInput.Nome;
        //     usuarioExistente.Email = usuarioInput.Email;
        //     usuarioExistente.Senha = usuarioInput.Senha;
        //     usuarioExistente.CPF = usuarioInput.CPF;
        //     usuarioExistente.RG = usuarioInput.RG;
        //     usuarioExistente.Nascimento = usuarioInput.Nascimento;
        //     usuarioExistente.Endereço = usuarioInput.Endereço;
        //     usuarioExistente.Status = usuarioInput.Status;
        //     usuarioExistente.Credito = usuarioInput.Credito;
        //     usuarioExistente.LinkLinkedln = usuarioInput.LinkLinkedln;
        //     usuarioExistente.Sobre = usuarioInput.Sobre;

        //     _usuarioRepository.Update(usuarioExistente);
        // }

        // private Usuario GetByDbId(int id)
        // {
        //     var _user = _context.Usuarios.Find(id);

        //     if (_user is null)
        //        // throw new UsuarioNotFoundException();

        //     return _user;
        // }
        // public void Delete(int id)
        // {
        //     var usuarioExistente = _usuarioRepository.GetById(id);

        //     if (usuarioExistente == null)
        //     {
        //         throw new UsuarioNotFoundException($"Usuário com ID {id} não encontrado.");
        //     }

        //     _usuarioRepository.Delete(usuarioExistente);
        // }

        // public UsuarioViewModel GetById(int id)
        // {
        //     var usuario = _usuarioRepository.GetById(id);

        //     if (usuario == null)
        //     {
        //         throw new UsuarioNotFoundException($"Usuário com ID {id} não encontrado.");
        //     }

        //     return new UsuarioViewModel
        //     {
        //         UsuarioId = usuario.UsuarioId,
        //         Nome = usuario.Nome,
        //         Email = usuario.Email,
        //         // Mapeie outros campos conforme necessário
        //     };
        // }

        // public List<UsuarioViewModel> GetAll()
        // {
        //     var usuarios = _usuarioRepository.GetAll();
        //     var usuariosViewModel = new List<UsuarioViewModel>();

        //     foreach (var usuario in usuarios)
        //     {
        //         usuariosViewModel.Add(new UsuarioViewModel
        //         {
        //             UsuarioId = usuario.UsuarioId,
        //             Nome = usuario.Nome,
        //             Email = usuario.Email,
        //             // Mapeie outros campos conforme necessário
        //         });
        //     }

        //     return usuariosViewModel;
        // }
    }
}