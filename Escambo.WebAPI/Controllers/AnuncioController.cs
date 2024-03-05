using Escambo.WebAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace Escambo.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class AnuncioController : Controller
{

    [HttpGet]
    [Route("anuncios")]
    public IActionResult GetAll()
    {
        // var usuario = new Usuario
        // {
        //     UsuarioId = 1,
        //     Nome = "Usuario 1"
        // };
        // var anuncios = Enumerable.Range(1, 5).Select(index => new Anuncio
        // {
        //     AnuncioId = index,
        //     Nome = $"Anuncio do Serviço {index}", 
        //     Usuario = usuario
        // })
        //   .ToArray();
        // return Ok(anuncios);

        return NoContent();
    }
    [HttpGet]
    [Route("anuncio/{id}")]
    public IActionResult GetById(int id)
    {
        // var usuario = new Usuario
        // {
        //     UsuarioId = 1,
        //     Nome = "Usuario 1"
        // };
        // var anuncio =  new Anuncio
        // {
        //     AnuncioId = id,
        //     Nome = $"Anuncio do Serviço {id}", 
        //     Usuario = usuario
        // };
    //   return Ok(anuncio);

        return NoContent();
   }
    [HttpPost]
    [Route("anuncio")]
    public IActionResult Post([FromBody] Anuncio anuncio)
    {
        // return CreatedAtAction(nameof(GetById), new { id = 1 }, anuncio);
        return NoContent();
    }
    [HttpPut("anuncio/{id}")]
   public IActionResult Put(int id, [FromBody] Anuncio anuncio)
   {
      //TODO: Buscar um anuncio pelo id e atualizar os dados
      // caso não encontre, retorna NotFound()
      return NoContent();
   }

   [HttpDelete("anuncio/{id}")]
   public IActionResult Delete(int id)
   {
      //TODO: Buscar um anuncio pelo id e apagar
      // caso não encontre, retorna NotFound()
      return NoContent();
   }
}
