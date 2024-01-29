
using Escambo.WebAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace Escambo.WebAPI.Controllers
{

    [ApiController]
    [Route("/api/v0.1/")]
    public class PrestacaoServicoController : Controller
    {
        
    [HttpGet]
    [Route("prestacoes")]
    public IActionResult GetAll()
    {   

        // var usuarioPrestador = new Usuario
        // {
        //     UsuarioId = 1,
        //     Nome = "Prestador 1"
        // };

        // var usuarioContratante = new Usuario
        // {
        //     UsuarioId = 2,
        //     Nome = "Contratante 1"
        // };

        // var prestacoes =Enumerable.Range(1, 5).Select(index => new PrestacaoServico
        // {
        //     AnuncioId = index,
        //     Status = 0,//Aceito
        //     DataInicio = DateTime.Now,
        //     ContratanteId = usuarioContratante.UsuarioId,
        //     Contratante = usuarioContratante,
        //     PrestadorId = usuarioPrestador.UsuarioId,
        //     Prestador = usuarioPrestador
        // })
        //   .ToArray();
        // return Ok(prestacoes);
        return NoContent();
        
    }

    [HttpGet]
    [Route("prestacao/{id}")]
    public IActionResult GetById(int id)
    {
        //  var usuarioPrestador = new Usuario
        // {
        //     UsuarioId = 1,
        //     Nome = "Prestador 1"
        // };

        // var usuarioContratante = new Usuario
        // {
        //     UsuarioId = 2,
        //     Nome = "Contratante 1"
        // };

        // var prestacao = new PrestacaoServico
        // {
        //     PrestacaoId = id,
        //     AnuncioId = 1,
        //     Status = 0,//Aceito
        //     DataInicio = DateTime.Now,
        //     ContratanteId = usuarioContratante.UsuarioId,
        //     Contratante = usuarioContratante,
        //     PrestadorId = usuarioPrestador.UsuarioId,
        //     Prestador = usuarioPrestador
        // };
        // return Ok(prestacao);

        return NoContent();
    }

    [HttpPost]
    [Route("prestacao")]
    public IActionResult Post([FromBody] PrestacaoServico prestacao)
    {
        // return CreatedAtAction(nameof(GetById), new { id = 1 }, prestacao);
        return NoContent();
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