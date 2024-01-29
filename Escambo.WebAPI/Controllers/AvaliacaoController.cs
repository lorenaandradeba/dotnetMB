
using Escambo.WebAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace Escambo.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]

public class AvaliacaoController : Controller{

    [HttpGet]
    [Route("avaliacoes")]

    public IActionResult GetAll(){
        return NoContent();

    }

    [HttpGet]
    [Route("avaliacao/{id}")]
    public IActionResult Get(int id){
        return NoContent();
    }  
    [HttpPost]
    [Route("avaliacao")]
    public IActionResult Post([FromBody] Avaliacao avaliacao){
        
        return NoContent();
    }
    [HttpPut]
    [Route("avaliacao/{id}")]
    public IActionResult Put(int id, [FromBody] Avaliacao avaliacao){
        return NoContent();
    }

    [HttpDelete]
    [Route("avaliacao/{id}")]
    public IActionResult Delete(int id){
        return NoContent();
    }
}