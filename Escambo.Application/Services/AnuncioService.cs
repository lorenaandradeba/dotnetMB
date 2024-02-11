using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Escambo.Application.InputModels;
using Escambo.Application.Services.Interfaces;
using Escambo.Application.ViewModels;
using Escambo.Dommain.Exceptions;
using Escambo.Dommain.Model;
using Escambo.Infra.Context;

namespace Escambo.Application.Services
{
    public class AnuncioService : BaseService, IAnuncioService
    {

        private readonly IAnuncioService _anuncioService;
        private readonly IUsuarioService _usuarioService;

        public AnuncioService(EscamboContext context, IAnuncioService anuncioService, IUsuarioService usuarioService) : base(context)
        {
            _anuncioService = anuncioService;
            _usuarioService = usuarioService;

        }
        public int Create(AnuncioInputModel anuncio)
        {
            var _usuario = _context.Usuarios.Where(u => u.UsuarioId == anuncio.UsuarioId).First();

            var newAnuncio = new Anuncio
            {
                NomeServico = anuncio.NomeServico,
                Descricao = anuncio.Descricao,
                Creditos = anuncio.Creditos,
                Categoria = anuncio.Categoria,
                Tipo = anuncio.Tipo,
                Usuario = _usuario,
                UsuarioId = anuncio.UsuarioId
            };

            _context.Anuncios.Add(newAnuncio);

            _context.SaveChanges();

            return newAnuncio.AnuncioId;
        }
        private Anuncio GetByDbId(int id)
        {
            var _anuncio = _context.Anuncios.Find(id);

            if (_anuncio is null)
                throw new AnuncioNotFoundException();

            return _anuncio;
        }
        public void Delete(int id)
        {
            _context.Anuncios.Remove(GetByDbId(id));
            _context.SaveChanges();
        }

        public List<AnuncioViewModel> GetAll()
        {
            var _anuncios = _context.Anuncios
            .Select(a => new AnuncioViewModel
            {
AnuncioId = a.AnuncioId,

            });
        }

        public AnuncioViewModel? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, AnuncioInputModel anuncio)
        {
            throw new NotImplementedException();
        }
    }
}