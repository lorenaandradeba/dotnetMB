
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
    public class PrestacaoServicoService : IPrestacaoServicoService
    {
         
        private readonly EscamboContext _context;
        public PrestacaoServicoService(EscamboContext context)
        {
            _context = context;
        }
        public int Create(PrestacaoServicoInputModel prestacao)
        {
           var id = _context.PrestacaoServicos.Count() + 1;
           var _prestacao = new PrestacaoServico{
            PrestacaoServicoId = id,
            ContratanteId = prestacao.ContratanteId,
            PrestadorId = prestacao.PrestadorId,
            Descrição = prestacao.Descrição,
            Credito = prestacao.Credito,
            Status = prestacao.Status,
            Data = prestacao.Data,
           };
           _context.PrestacaoServicos.Add(_prestacao);
           _context.SaveChanges();
           return _prestacao.PrestacaoServicoId;
        }

        public void Delete(int id)
        {
          var _prestacao = _context.PrestacaoServicos.Find(id);
          if (_prestacao == null)
            return;
          _context.PrestacaoServicos.Remove(_prestacao);
          _context.SaveChanges();
        }

        public List<PrestacaoServicoViewModel> GetAll(){
          var _prestacao = _context.PrestacaoServicos.ToList();
          return _prestacao.Select(x => new PrestacaoServicoViewModel{
                PrestacaoServicoId = x.PrestacaoServicoId,
                ContratanteId = x.ContratanteId,
                PrestadorId = x.PrestadorId,
                Descrição = x.Descrição,
                Credito = x.Credito,
                Status = x.Status,
                Data = x.Data,
                AnuncioIdAnuncio = x.AnuncioIdAnuncio,
                
          }).ToList();
        }

        public PrestacaoServicoViewModel? GetById(int id)
        {
            var _prestacao = _context.PrestacaoServicos.Find(id);

            return new PrestacaoServicoViewModel{
                PrestacaoServicoId = _prestacao.PrestacaoServicoId,
                ContratanteId = _prestacao.ContratanteId,
                PrestadorId = _prestacao.PrestadorId,
                Descrição = _prestacao.Descrição,
                Credito = _prestacao.Credito,
                Status = _prestacao.Status,
                Data = _prestacao.Data,
            };
        }

        public void Update(int id, PrestacaoServicoInputModel prestacao)
        {
           var _prestacao = _context.PrestacaoServicos.Find(id);
           if (_prestacao == null)
            return;

            _prestacao.Duração = prestacao.Duração;
            _prestacao.Categoria = prestacao.Categoria;
            _prestacao.Descrição = prestacao.Descrição;
            _prestacao.Credito = prestacao.Credito;
            _prestacao.Status = prestacao.Status;
            _prestacao.Data = prestacao.Data;

            _context.Update(_prestacao);
            _context.SaveChanges();
        }
    }
}