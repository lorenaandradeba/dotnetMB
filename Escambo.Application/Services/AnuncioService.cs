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
            var newAnuncio = new Anuncio
            {
                NomeServico = anuncio.NomeServico,
                Descricao = anuncio.Descricao,
                Creditos = anuncio.Creditos,
                Categoria = anuncio.Categoria,
                Tipo = anuncio.Tipo,
                UsuarioId = anuncio.UsuarioId
            };
            
            _context.Anuncios.Add(newAnuncio);

            _context.SaveChanges();

            return newAnuncio.UserId;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<AnuncioViewModel> GetAll()
        {
            throw new NotImplementedException();
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