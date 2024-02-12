using Microsoft.AspNetCore.Mvc;
using TechMed.Application.Model.Input;
using TechMed.Application.Model.View;
using TechMed.Application.Service.Interface;

namespace TechMed.WebAPI.Controller;

[ApiController]
[Route("[controller]")]
public class MedicoContoller : ControllerBase
{
    
    protected readonly IMedicoService? _medicoService;
    public List<MedicoViewModel> Medicos => _medicoService.GetAll();

    public MedicoContoller(IMedicoService service){
        _medicoService = service;
    }

    [HttpGet ("Medico/All")]
    public ActionResult GetAll(){
        return Ok(Medicos);
    }

    [HttpGet ("Medico/{id}")]
    public ActionResult GetById(int id)
    {
        var _medico = _medicoService.GetById(1);
        if(_medico is null){
            return NotFound();
        }
        return Ok(_medico);
    }

    [HttpPost ("Medico/New")]
    public ActionResult Create(MedicoInputModel medico)
    {
        _medicoService.Create(medico);
        return Ok();
        
    }

    [HttpDelete ("Medico/{id}")]
    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

}
