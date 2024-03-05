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
    public class AvaliacaoService : IAvaliacaoService
    {

        private readonly EscamboContext _context;
        public AvaliacaoService(EscamboContext context)
        {
            _context = context;
        }
        public int Create(AvaliacaoInputModel avaliacao)
        {
            var id = _context.Avaliacoes.Count() + 1;
            var _avaliacao = new Avaliacao
            {
                AvaliacaoId = id,
                Mensagem = avaliacao.Mensagem,
                Estrelas = avaliacao.Estrelas,

            };

            _context.Avaliacoes.Add(_avaliacao);
            _context.SaveChanges();

            return _avaliacao.AvaliacaoId;
        }

        public void Delete(int id)
        {
            var avaliacao = _context.Avaliacoes.Find(id);
            _context.Avaliacoes.Remove(avaliacao);
            _context.SaveChanges();
        }

        public List<AvaliacaoViewModel> GetAll()
        {
            var _avaliacoes = _context.Avaliacoes.Select(x => new AvaliacaoViewModel
            {
                AvaliacaoId = x.AvaliacaoId,
                Estelas = x.Estrelas,
                Mensagem = x.Mensagem
            }).ToList();
            return _avaliacoes;
        }

        public AvaliacaoViewModel? GetById(int id)
        {
           var _avaliacao = _context.Avaliacoes.Find(id);
           if (_avaliacao == null)
                return null;

            return new AvaliacaoViewModel
            {
                AvaliacaoId = _avaliacao.AvaliacaoId,
                Estelas = _avaliacao.Estrelas,
                Mensagem = _avaliacao.Mensagem
            };

        }

        public void Update(int id, AvaliacaoInputModel avaliacao)
        {
            var _avaliacao = _context.Avaliacoes.Find(id);
            if (_avaliacao == null)
                return;
            _avaliacao.Mensagem = avaliacao.Mensagem;
            _avaliacao.Estrelas = avaliacao.Estrelas;
            
            _context.Avaliacoes.Update(_avaliacao);
            _context.SaveChanges();
        }
    }
}