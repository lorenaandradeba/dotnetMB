using Escambo.Application.InputModels;
using Escambo.Application.Services.Interfaces;
using Escambo.Application.ViewModels;
using Escambo.WebAPI.Controllers.Interface;
using Microsoft.AspNetCore.Mvc;


namespace Escambo.WebAPI.Controllers;

[ApiController]
[Route("Escambo/")]
public class AvaliacaoController : ControllerBase, IAvaliacaoController
{

    protected readonly IAvaliacaoService _avaliacaoService;
    public List<AvaliacaoViewModel> _avaliacoes => _avaliacaoService.GetAll().ToList();
    public AvaliacaoController(IAvaliacaoService avaliacaoService) => _avaliacaoService = avaliacaoService;
    
    [HttpPost("Avaliacao")]
    public IActionResult Create(AvaliacaoInputModel input)
    {
       var id = _avaliacaoService.Create(input);
       if(id == 0) return BadRequest();
       return Ok(id);
    }

    [HttpDelete("Avaliacao/{id}")]
    public IActionResult Delete(int id)
    {
       _avaliacaoService.Delete(id);
       return Ok();
    }

    [HttpGet("Avaliacao/all")]
    public IActionResult GetAll()
    {
        return Ok(_avaliacoes);
    }
    [HttpGet("Avaliacao/{id}")]

    public IActionResult GetById(int id)
    {
       var avaliacao = _avaliacaoService.GetById(id);
       if(avaliacao is not null) return Ok(avaliacao);

       return NotFound();
    }
     [HttpPost("Avaliacao/{id}")]
    public IActionResult Update(int id, AvaliacaoInputModel input)
    {
        _avaliacaoService.Update(id, input);
        return Ok();
    }
}