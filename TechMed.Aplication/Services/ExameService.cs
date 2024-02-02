using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechMed.Aplication.InputModel;
using TechMed.Aplication.Services.Interfaces;
using TechMed.Aplication.ViewModel;
using TechMed.Infrastructure.Persistence;

namespace TechMed.Aplication.Services
{
    public class ExameService : BaseService, IExameService
    {
        private readonly IAtendimentoService _atendimentoService;
        public ExameService(TechMedDbContext context, IAtendimentoService atendimento) : base(context)
        {
            _atendimentoService = atendimento;
        }

        public int Create(int atendimentoId, NewExameInputModel exame)
        {
            return _atendimentoService.CreateExame(atendimentoId, exame);
        }

        public List<ExameViewModel> GetAll()
        {

            return _context.Exames.Select(e => new ExameViewModel
            {
                ExameId = e.ExameId,
                Nome = e.Nome,
                DataHora = e.DataHora,
                Atendimento = new AtendimentoViewModel
                {
                    AtendimentoId = e.AtendimentoId,
                    DataHora = e.Atendimento.DataHora,
                    Medico = new MedicoViewModel
                    {
                        MedicoId = e.Atendimento.MedicoId,
                        Nome = e.Atendimento.Medico.Nome
                    },
                    Paciente = new PacienteViewModel
                    {
                        PacienteId = e.Atendimento.PacienteId,
                        Nome = e.Atendimento.Paciente.Nome
                    }
                },

            }).ToList();
        }
    }
}