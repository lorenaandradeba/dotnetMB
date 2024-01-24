using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Escambo.WebAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace Escambo.WebAPI.Controllers
{

    [ApiController]
    [Route("/api/v0.1/")]
    public class PrestacaoServicoController : ControllerBase
    {
        
    [HttpGet]
    [Route("prestacoes")]
    public IActionResult GetAll()
    {

    }

    [HttpGet]
    [Route("prestacao/{id}")]
    public IActionResult GetById(int id)
    {
    }

    [HttpPost]
    [Route("prestacao")]
    public IActionResult Post([FromBody] PrestacaoServico prestacao)
    {

    }

    [HttpPut("prestacao/{id}")]
   public IActionResult Put(int id, [FromBody] Anuncio anuncio)
   {
      //TODO: Buscar um anuncio pelo id e atualizar os dados
      // caso não encontre, retorna NotFound()
      return NoContent();
   }

   [HttpDelete("prestacao/{id}")]
   public IActionResult Delete(int id)
   {
      //TODO: Buscar um anuncio pelo id e apagar
      // caso não encontre, retorna NotFound()
      return NoContent();
   }
    }
}