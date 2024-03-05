using Escambo.WebAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace Escambo.WebAPI.Controllers;
[ApiController]
[Route("/api/v0.1/")]
public class MensagemController: Controller{
    
    [HttpGet]
    [Route("menssagens")]
    public IActionResult GetAll(){
        return NoContent();
    }
    [HttpGet]
    [Route("menssagens/chat/{ChatId}")]
    public IActionResult GetAllMessagensByChat(int ChatId){
        return NoContent();
    }

    [HttpDelete]
    [Route("menssagem/{id}")]

    public IActionResult Delete(int id){
        return NoContent();
    }
    [HttpPost]
    [Route("menssagem/chat/{ChatId}")]
    public IActionResult Post([FromBody] Mensagem mensagem, int ChatId){
        return NoContent();
    }

    [HttpPut]
    [Route("menssagem/{id}")]
    public IActionResult Put(int id, [FromBody] Mensagem mensagem){
        return NoContent();
    }
