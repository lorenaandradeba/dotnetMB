using Escambo.Application.InputModels;
using Escambo.Application.Services.Interfaces;
using Escambo.Application.ViewModels;
using Escambo.WebAPI.Controllers.Interface;
using Microsoft.AspNetCore.Mvc;



namespace Escambo.WebAPI.Controllers;

[ApiController]
[Route("Escambo/")]
public class MensagemController : ControllerBase, IMensagemController
{

    protected readonly IMensagemService _mensagenService;
    public List<MensagemViewModel> _mensagens => _mensagenService.GetAll().ToList();
    public MensagemController(IMensagemService mensagemService) => _mensagenService = mensagemService;

    public IActionResult Create(MensagemInputModel input)
    {
       var id = _mensagenService.Create(input);
       if(id == 0) return BadRequest();

       return Ok(id);
    }

    [HttpGet("Mensagem/all")]
    public IActionResult GetAll()
    {
        if(_mensagens == null) return NotFound();

        return Ok(_mensagens);
    }

    [HttpGet("Mensagem/{id}")]
    public IActionResult GetById(int id)
    {
        var _mensagem = _mensagenService.GetById(id);
        if(_mensagem is not null)  return Ok(_mensagem);

        return NotFound();
    }

    [HttpPost("Mensagem/{id}")]
    public IActionResult Update(int id, MensagemInputModel input)
    {
        _mensagenService.Update(id, input);
        return Ok();
    }
    [HttpDelete("Mensagem/{id}")]
    public IActionResult Delete(int id)
    {
        _mensagenService.Delete(id);
       return Ok();
    }
}