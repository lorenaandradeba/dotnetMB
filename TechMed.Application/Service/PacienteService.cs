
using TechMed.Application.Model.Input;
using TechMed.Application.Model.View;
using TechMed.Application.Service.Interface;
using TechMed.Application.Services;
using TechMed.Core.Entities;
using TechMed.Infrastructure.Context;

public class PacienteService : BaseService, IPacienteService
{
   

    private int _id { get; set; } = 0;

    public PacienteService(TechMedContext context) : base(context){} //pasando o contexto para o construtor da classe base
   
    public int Create(PacienteInputModel medico)
    {
        var id = _context.Pacientes.Count() > 0 ? _context.Pacientes.Max(m => m.PacienteId) + 1 : 1;
        var _paciente = new Paciente
        {
            PacienteId = id,
            Nome = medico.Name
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
       var _pacientes = _context.Pacientes.Select(m => new PacienteViewModel
        {
            PacienteId = m.PacienteId,
            Nome = m.Nome
        }).ToList();

        return _pacientes;

    }

    public PacienteViewModel? GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(int id, PacienteInputModel paciente)
    {
        throw new NotImplementedException();
    }
}