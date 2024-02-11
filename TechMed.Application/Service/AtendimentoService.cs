using TechMed.Application.Model.Input;
using TechMed.Application.Model.View;
using TechMed.Application.Service.Interface;
using TechMed.Application.Services;
using TechMed.Core.Entities;
using TechMed.Infrastructure.Context;

namespace TechMed.Application.Service;


public class AtendimentoService: BaseService, IAtendimentoService
{
    protected readonly IMedicoService _medicoService;
    protected readonly IPacienteService _pacienteService;
    public AtendimentoService(TechMedContext context, IMedicoService medicoService, IPacienteService pacienteService) : base(context) {
        _medicoService = medicoService;
        _pacienteService = pacienteService;
     } //Passas o contexto 

    public List<AtendimentoViewModel> GetAll()
    {
      
    
        var _atendimentos = _context.Atendimentos.Select(a => new AtendimentoViewModel
        {
            AtendimentoId = a.AtendimentoId,
            DataHoraInicio = a.DataHoraInicio,
            SuspeitaInicial = a.SuspeitaInicial,
            Medico = new MedicoViewModel { MedicoId = a.MedicoId, Nome = a.Medico.Nome,CRM = a.Medico.CRM },
            Paciente = new PacienteViewModel { PacienteId = a.PacienteId, Nome = a.Paciente.Nome },
            
        }).ToList();

        return _atendimentos;
    }

    public AtendimentoViewModel GetById(int id)
    {

        var _atendimentos = _context.Atendimentos.Find(id);
        if (_atendimentos is not null)
        {
            return new AtendimentoViewModel
            {

                AtendimentoId = _atendimentos.AtendimentoId,
                DataHoraInicio = _atendimentos.DataHoraInicio,
                DataHoraFim = _atendimentos.DataHoraFim,
                SuspeitaInicial = _atendimentos.SuspeitaInicial,
                Diagnostico = _atendimentos.Diagnostico,

                Medico = _medicoService.GetById(_atendimentos.MedicoId),
                Paciente = _pacienteService.GetById(_atendimentos.PacienteId),

            };
        }
        return null;
    }

    public int Create(AtendimentoInputModel _newAtendimento)
    {
        var id = _context.Atendimentos.Count() > 0 ? _context.Atendimentos.Max(m => m.AtendimentoId) + 1 : 1;
        var medico = _context.Medicos.Find(_newAtendimento.MedicoId);
        var paciente = _context.Pacientes.Find(_newAtendimento.PacienteId);

        if (medico is not null && paciente is not null)
        {
            var _atendimento = new Atendimento
            {
                AtendimentoId = id,
                PacienteId = paciente.PacienteId,
                Paciente = paciente,
                MedicoId = medico.MedicoId,
                Medico = medico,
                DataHoraInicio = DateTimeOffset.Now,
                SuspeitaInicial = _newAtendimento.SuspeitaInicial,
            };
             _context.Atendimentos.Add(_atendimento);
            _context.SaveChanges();
            
            return _atendimento.AtendimentoId;
       }
       return 0;
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }


    public void Update(int id, AtendimentoInputModel Entity)
    {
        throw new NotImplementedException();
    }
}