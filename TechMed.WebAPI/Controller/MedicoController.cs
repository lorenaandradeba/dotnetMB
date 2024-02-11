using Microsoft.AspNetCore.Mvc;
using TechMed.Application.Model.Input;
using TechMed.Application.Model.View;
using TechMed.Application.Service.Interface;

namespace TechMed.WebAPI.Controller;

[ApiController]
[Route("Medico")]
public class MedicoContoller : ControllerBase
{
    
    protected readonly IMedicoService? _medicoService;
    public List<MedicoViewModel> Medicos => _medicoService.GetAll();

    public MedicoContoller(IMedicoService service){
        _medicoService = service;
    }

    [HttpGet ("Medicos")]
    public ActionResult GetAll(){
        return Ok(Medicos);
    }

    [HttpGet ("Medico/{id}")]
    public ActionResult GetById(int id)
    {
        throw new NotImplementedException();
    }

    [HttpPost ("Medico")]
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
