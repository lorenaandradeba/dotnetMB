using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TechMed.Aplication.InputModel;
using TechMed.Aplication.Services.Interfaces;
using TechMed.Aplication.ViewModel;
using TechMed.Dommain.Entities;
using TechMed.Dommain.Exceptions;
using TechMed.Infrastructure.Persistence;

namespace TechMed.Aplication.Services
{
    public class AtendimentoService : BaseService, IAtendimentoService
    {


        private readonly IMedicoService _medicoService;
        public AtendimentoService(TechMedDbContext context, IMedicoService medico) : base(context)
        {
            _medicoService = medico;
        }
        public int Create(NewAtendimentoInputModel atendimento)
        {
            return _medicoService.CreateAtendimento(atendimento.MedicoId, atendimento);
        }

        public int CreateExame(int atendimentoId, NewExameInputModel exame)
        {

            var _atendimento = _context.Atendimentos.Where(a => a.AtendimentoId == atendimentoId).First();

            var _exame = _context.Exames.Add(new Exame
            {
                Nome = exame.Nome,
                DataHora = exame.DataHora,
                Atendimento = _atendimento
            });

            _context.SaveChanges();

            return _exame.Entity.ExameId;
        }

        public List<AtendimentoViewModel> GetAll()
        {

            return _context.Atendimentos.Select(a => new AtendimentoViewModel
            {
                AtendimentoId = a.AtendimentoId,
                DataHora = a.DataHora,
                Medico = new MedicoViewModel
                {
                    MedicoId = a.Medico.MedicoId,
                    Nome = a.Medico.Nome
                },
                Paciente = new PacienteViewModel
                {
                    PacienteId = a.Paciente.PacienteId,
                    Nome = a.Paciente.Nome
                }
            }).ToList();
        }

        public AtendimentoViewModel? GetById(int id)
        {
            var _atendimento = _context.Atendimentos
            .Include(a => a.Medico) 
            .Include(a => a.Paciente)
            .Where(a => a.AtendimentoId == id).First();
            

            if (_atendimento is null)
                throw new AtendimentoNotFoundException();

            var AtendimentoViewModel = new AtendimentoViewModel
            {
                AtendimentoId = _atendimento.AtendimentoId,
                DataHora = _atendimento.DataHora,
                Medico = new MedicoViewModel
                {
                    MedicoId = _atendimento.Medico.MedicoId,
                    Nome = _atendimento.Medico.Nome
                },
                Paciente = new PacienteViewModel
                {
                    PacienteId = _atendimento.Paciente.PacienteId,
                    Nome = _atendimento.Paciente.Nome
                }

            };
            return AtendimentoViewModel;
        }

        public List<AtendimentoViewModel> GetByMedicoId(int medicoId)
        {
            var _atendimentos = _context.Atendimentos
            .Include(a => a.Medico) 
            .Include(a => a.Paciente)
            .Where(a => a.Medico.MedicoId == medicoId)
            .ToList();

            return _atendimentos.Select(a => new AtendimentoViewModel
            {
                AtendimentoId = a.AtendimentoId,
                DataHora = a.DataHora,
                Medico = new MedicoViewModel
                {
                    MedicoId = a.Medico.MedicoId,
                    Nome = a.Medico.Nome
                },
                Paciente = new PacienteViewModel
                {
                    PacienteId = a.Paciente.PacienteId,
                    Nome = a.Paciente.Nome
                }
            }).ToList();
        }

        public List<AtendimentoViewModel> GetByPacienteId(int pacienteId)
        {
            var _atendimentos = _context.Atendimentos
            .Include(a => a.Medico) 
            .Include(a => a.Paciente)
            .Where(a => a.Paciente.PacienteId == pacienteId)
            .ToList();


            return _atendimentos.Select(a => new AtendimentoViewModel
            {
                AtendimentoId = a.AtendimentoId,
                DataHora = a.DataHora,
                Medico = new MedicoViewModel
                {
                    MedicoId = a.Medico.MedicoId,
                    Nome = a.Medico.Nome
                },
                Paciente = new PacienteViewModel
                {
                    PacienteId = a.Paciente.PacienteId,
                    Nome = a.Paciente.Nome
                }
            }).ToList();
        }

        public List<AtendimentoViewModel> GetByPeriodos(DateTime inicio, DateTime fim)
        {
            var _atendimentos = _context.Atendimentos
            .Include(a => a.Medico) 
            .Include(a => a.Paciente)
            .Where(a => a.DataHora >= inicio && a.DataHora <= fim)
            .ToList();

            return _atendimentos.Select(a => new AtendimentoViewModel
            {
                AtendimentoId = a.AtendimentoId,
                DataHora = a.DataHora,
                Medico = new MedicoViewModel
                {
                    MedicoId = a.Medico.MedicoId,
                    Nome = a.Medico.Nome
                },
                Paciente = new PacienteViewModel
                {
                    PacienteId = a.Paciente.PacienteId,
                    Nome = a.Paciente.Nome
                }
            }).ToList();
        }
    }
}