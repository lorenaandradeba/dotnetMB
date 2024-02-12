
using TechMed.Application.Model.Input;
using TechMed.Application.Model.View;
using TechMed.Application.Service.Interface;
using TechMed.Application.Services;
using TechMed.Core.Entities;
using TechMed.Infrastructure.Context;

public class PacienteService : BaseService, IPacienteService
{
   
    public PacienteService(TechMedContext context) : base(context){} //pasando o contexto para o construtor da classe base
   
    public int Create(PacienteInputModel paciente)
    {
        var id = _context.Pacientes.Count() > 0 ? _context.Pacientes.Max(p => p.PacienteId) + 1 : 1;
        var _paciente = new Paciente
        {
            PacienteId = id,
            Nome = paciente.Name,
            CPF = paciente.CPF, 
        
        };
        _context.Pacientes.Add(_paciente);

        _context.SaveChanges();

        return _paciente.PacienteId;
    }


    public void Delete(int id)
    {
        var paciente = _context.Pacientes.Find(id);
        if( paciente is not null){
            _context.Pacientes.Remove(paciente);
            _context.SaveChanges();
        }
        
    }

    public List<PacienteViewModel> GetAll()
    {
       var _pacientes = _context.Pacientes.Select(p => new PacienteViewModel
        {
            PacienteId = p.PacienteId,
            Nome = p.Nome,
            CPF = p.CPF
        }).ToList();

        return _pacientes;

    }

    public PacienteViewModel? GetById(int id)
    {
        var _paciente = _context.Pacientes.Find(id);
        if(_paciente is not null){
          return new PacienteViewModel { PacienteId = _paciente.PacienteId, Nome = _paciente.Nome };
        }
        return null;
    }

    public void Update(int id, PacienteInputModel paciente)
    {
      var _paciente = _context.Pacientes.Find(id);
        _paciente.Nome = paciente.Name;
        _paciente.CPF = paciente.CPF;
    }
}