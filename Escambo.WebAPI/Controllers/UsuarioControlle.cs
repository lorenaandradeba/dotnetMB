using Microsoft.AspNetCore.Mvc;
using Escambo.WebAPI.Model;

namespace Escambo.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class UsuarioController : ControllerBase
{
    
    [HttpGet] 
    [Route("usuario/{id}")]
    public IActionResult Get(int id)
    {
        return Ok();
    }

    [HttpGet]
    [Route("usuarios")]
       public IActionResult GetAll(int id)
    {
        var nome = "Danie";
        return Ok(nome);
    }
    [HttpPost]
    [Route("usuario/cadastro")]
    public IActionResult Post([FromBody] Usuario usuario){
        return Ok(usuario.ToString());
    }

   [HttpGet("usuario/{id}/anuncios")]
   public IActionResult GetAnuncios(int id)
   {
      var anuncio = Enumerable.Range(1, 5).Select(index => new Anuncio
        {
            AnuncioId = index,
            Nome = "Corte de Cabelo",
            UsuarioId = id,
            Usuario = new Usuario
            {
                UsuarioId = id,
                Nome = $"Usuario {id}"
            }
        })
        .ToArray();
      return Ok(anuncio);
   }
}
