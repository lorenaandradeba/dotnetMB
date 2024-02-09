using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using TechMed.Application.Model.Input;
using TechMed.Application.Model.View;
using TechMed.Application.Service.Interface;
using TechMed.Core.Entities;

namespace TechMed.WebAPI.Controller;

[ApiController]
[Route("Pacientes")]
public class PacienteController: ControllerBase
{
    protected readonly IPacienteService _pacienteService;
    public List<PacienteViewModel> Pacientes => _pacienteService.GetAll();
    public PacienteController(IPacienteService service){
        _pacienteService = service;
    }

    [HttpGet ("Pacientes")]

    public IActionResult GetAll(){
        return Ok(Pacientes);
    }   

    [HttpPost ("Paciente")]
    public IActionResult Create(PacienteInputModel paciente){
        _pacienteService.Create(paciente);
        return Ok();
    }

}