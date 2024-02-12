namespace TechMed.Application.Services;

using System.Collections.Generic;
using TechMed.Application.Model.Input;
using TechMed.Application.Model.View;
using TechMed.Application.Service.Interface;
using TechMed.Core.Entities;
using TechMed.Infrastructure.Context;

public class ExameService :BaseService, IExameService
{
    

    public ExameService(TechMedContext context):base(context){ 
       
    }
   
    public int Create(int AtendimentoId, ExameInputModel exame)
    {

        var _atendimento = _context.Atendimentos.Find(AtendimentoId);
        var _id = _context.Exames.Count() > 0 ? _context.Exames.Max(e => e.ExameId) + 1 : 1;
        if(_atendimento is null) return 0;
        var _exame = new Exame{
            ExameId = _id,
            Nome = exame.Nome,
            DataHora = exame.DataHora,
            Valor = exame.Valor,
            Local = exame.Local,
        };
        _exame.Atendimentos.Add(_atendimento);
        _atendimento.Exames.Add(_exame);
        _context.Exames.Add(_exame);
        _context.Atendimentos.Update(_atendimento);
        _context.SaveChanges();
        return _exame.ExameId;
    }

    public int Create(ExameInputModel Enity)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        var exame = _context.Exames.Find(id);
        if(exame is not null){
            _context.Exames.Remove(exame);
        }
    }

    public List<ExameViewModel> GetAll()
    {
       var exames = _context.Exames.Select(e => new ExameViewModel{
           ExameId = e.ExameId,
           ExameNome = e.Nome,
           DataHora = e.DataHora,
           ResultadoDescricao = e.ResultadoDescricao,
           Local = e.Local,

       }).ToList();

       return exames;
    }

  

    public ExameViewModel? GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(int id, ExameInputModel Entity)
    {
        throw new NotImplementedException();
    }
}