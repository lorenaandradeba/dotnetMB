using Microsoft.AspNetCore.Mvc;
using TechMed.Application.Model.Input;
using TechMed.Application.Model.View;
using TechMed.Application.Service.Interface;
namespace TechMed.WebAPI.Controller;

[ApiController]
[Route("Atendimento")]
public class AtendimentoControler: ControllerBase
{
    protected IAtendimentoService _atendimentoService;
    protected List<AtendimentoViewModel> Atendimentos => _atendimentoService.GetAll();
    public AtendimentoControler(IAtendimentoService service){
        _atendimentoService = service;
    }


    [HttpGet ("Atenditmentos")]
    public IActionResult GetAll(){
        if (Atendimentos is not null)
            return Ok(Atendimentos);

        return NotFound();
    }

    [HttpGet ("Atendimento/{id}")]

    public IActionResult GetById(int id){
        var _atendimento = _atendimentoService.GetById(id);
        if (_atendimento is not null)
            return Ok(_atendimento);
        
        return NotFound();
    }

    [HttpPost ("Atendimentos")]
    public IActionResult Create(AtendimentoInputModel atendimento){
        var id = _atendimentoService.Create(atendimento);
        if (id > 0)
            return Ok(id);

        return BadRequest();
    }

}

