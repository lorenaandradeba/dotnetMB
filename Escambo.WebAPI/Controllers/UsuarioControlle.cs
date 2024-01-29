using Microsoft.AspNetCore.Mvc;
using Escambo.WebAPI.Model;


namespace Escambo.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class UsuarioController : Controller
{

    // List<Usuario> usuarios = new List<Usuario>();  
    
    [HttpGet] 
    [Route("usuario/{id}")]

    public IActionResult Get(int id)
    {
      // var usuario = usuarios.FirstOrDefault(u => u.UsuarioId == id);
      // if (usuario == null){
      //   return NoContent();
      // }else{
      //     return Ok(usuario.ToString());
      // }
      return NoContent();
    }

    [HttpGet]
    [Route("usuarios")]
    public IActionResult GetAll(int id)
    {
       
        // return Ok(usuarios.ToString());
      return NoContent();
    }

    [HttpPost]
    [Route("usuario/cadastro")]
    public IActionResult Post([FromBody] Usuario usuario){
        // return Ok(usuario.ToString());
        return NoContent();
    }
}
