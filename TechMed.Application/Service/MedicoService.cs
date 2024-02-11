using TechMed.Application.Model.Input;
using TechMed.Application.Model.View;
using TechMed.Application.Service.Interface;
using TechMed.Application.Services;
using TechMed.Core.Entities;
using TechMed.Infrastructure.Context;

namespace TechMed.Application.Service;

public class MedicoService: BaseService, IMedicoService
{
    public MedicoService(TechMedContext context) : base(context){} //pasando o contexto para o construtor da classe base

    public int Create(MedicoInputModel medico)
    {
        var id = _context.Medicos.Count() > 0 ? _context.Medicos.Max(m => m.MedicoId) + 1 : 1;
        var _medico = new Medico{
            MedicoId = id,
            CRM = id.ToString(),
            Nome = medico.Name
        };

        _context.Medicos.Add(_medico);

        _context.SaveChanges();

        return _medico.MedicoId;

    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }
    
    public List<MedicoViewModel> GetAll()
    {
       var _medicos = _context.Medicos.Select(m => new MedicoViewModel{
            MedicoId = m.MedicoId,
            Nome = m.Nome,
            CRM = m.CRM,
       });

       return _medicos.ToList();
    }


    public MedicoViewModel GetById(int id)
    {
        var _medico = _context.Medicos.Find(id);
        if(_medico is not null){
            return new MedicoViewModel { MedicoId = _medico.MedicoId, Nome = _medico.Nome };
        }
        return null;
    }

    public void Update(int id, MedicoInputModel Entity)
    {
        throw new NotImplementedException();
    }
}