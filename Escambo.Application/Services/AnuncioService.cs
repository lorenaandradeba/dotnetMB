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
using Microsoft.EntityFrameworkCore;

namespace Escambo.Application.Services
{
    public class AnuncioService : IAnuncioService
    {

        private readonly EscamboContext _context;

        public AnuncioService(EscamboContext context) => _context = context;

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
            var anuncios = _context.Anuncios
            .Include(a => a.Usuario)
            .Select(a => new AnuncioViewModel
            {
                AnuncioId = a.AnuncioId,
                NomeServico = a.NomeServico,
                Descricao = a.Descricao,
                Creditos = a.Creditos,
                Categoria = a.Categoria,
                Tipo = a.Tipo,
                UsuarioId = a.UsuarioId,
                Usuario = a.Usuario != null ? new UsuarioViewModel
                {
                    Nome = a.Usuario.Nome!,
                    Email = a.Usuario.Email,
                } : null
            }).ToList();

            return anuncios;
        }

        public AnuncioViewModel? GetById(int id)
        {
            var anuncio = _context.Anuncios
        .Include(a => a.Usuario)
        .FirstOrDefault(a => a.AnuncioId == id);

            if (anuncio == null)
                return null;

            return new AnuncioViewModel
            {
                AnuncioId = anuncio.AnuncioId,
                NomeServico = anuncio.NomeServico,
                Descricao = anuncio.Descricao,
                Creditos = anuncio.Creditos,
                Categoria = anuncio.Categoria,
                Tipo = anuncio.Tipo,
                UsuarioId = anuncio.UsuarioId,
                Usuario = anuncio.Usuario != null ? new UsuarioViewModel
                {
                    Nome = anuncio.Usuario.Nome!,
                    Email = anuncio.Usuario.Email,
                } : null
            };
        }

        public void Update(int id, AnuncioInputModel anuncio)
        {
            var anuncioToUpdate = _context.Anuncios
                .Include(a => a.Usuario) 
                .FirstOrDefault(a => a.AnuncioId == id);

            if (anuncioToUpdate == null)
            {
                return;
            }

            anuncioToUpdate.NomeServico = anuncio.NomeServico;
            anuncioToUpdate.Descricao = anuncio.Descricao;
            anuncioToUpdate.Creditos = anuncio.Creditos;
            anuncioToUpdate.Categoria = anuncio.Categoria;
            anuncioToUpdate.Tipo = anuncio.Tipo;
            anuncioToUpdate.UsuarioId = anuncio.UsuarioId;

            _context.SaveChanges();
        }
    }
}