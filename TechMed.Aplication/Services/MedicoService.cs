using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechMed.Aplication.InputModel;
using TechMed.Aplication.Services.Interfaces;
using TechMed.Aplication.ViewModel;
using TechMed.Dommain.Entities;
using TechMed.Dommain.Exceptions;
using TechMed.Infrastructure.Persistence;

namespace TechMed.Aplication.Services
{
    public class MedicoService : IMedicoService
    {
        private readonly TechMedDbContext _context;
        public MedicoService(TechMedDbContext context)
        {
            _context = context;
        }
        public Medico GetByDbId(int id)
        {
            var _medico = _context.Medicos.Find(id);
            if (_medico is null)
                throw new MedicoNotFoundException();
            return _medico;
        }
        public Medico GetByDbCrm(string crm)
        {
            var _medico = _context.Medicos.Where(m => m.CRM == crm).First();
            if (_medico is null)
                throw new MedicoNotFoundException();
            return _medico;
        }
        public int Create(NewMedicoInputModel medico)
        {
            var _medico = new Medico
            {
                Nome = medico.Nome!,
            };

            _context.Medicos.Add(_medico);

            _context.SaveChanges();

            return _medico.MedicoId;
        }
        public int CreateAtendimento(int medicoId, NewAtendimentoInputModel atendimento)
        {
            var _medico = GetByDbId(medicoId);
        
            var _paciente = _context.Pacientes.Find(atendimento.PacienteId);
            if (_paciente is null)
                throw new PacienteNotFoundException();
            
            var _atendimento =  _context.Atendimentos.Add(new Atendimento
            {
                DataHora = atendimento.DataHora,
                Medico = _medico,
                Paciente = _paciente
            });

            _context.SaveChanges();

            return _atendimento.Entity.AtendimentoId;

        }

        public void Delete(int id)
        {
            _context.Medicos.Remove(GetByDbId(id));
            _context.SaveChanges();
        }

        public List<MedicoViewModel> GetAll()
        {
            var _medicos = _context.Medicos.Select(m => new MedicoViewModel
            {
                MedicoId = m.MedicoId,
                Nome = m.Nome,
            }).ToList();

            return _medicos;
        }

        public MedicoViewModel? GetByCrm(string crm)
        {
            var _medico = GetByDbCrm(crm);
            var MedicoViewModel = new MedicoViewModel
            {
                MedicoId = _medico.MedicoId,
                Nome = _medico.Nome
            };
            return MedicoViewModel;
        }

        public MedicoViewModel? GetById(int id)
        {
            var _medico = GetByDbId(id);
            var MedicoViewModel = new MedicoViewModel
            {
                MedicoId = _medico.MedicoId,
                Nome = _medico.Nome
            };
            return MedicoViewModel;
        }
        public void Update(int id, NewMedicoInputModel medico)
        {
            var _medico = GetByDbId(id);
            _medico.Nome = medico.Nome!;
            _context.Medicos.Update(_medico);
            _context.SaveChanges();
        }
    }
}