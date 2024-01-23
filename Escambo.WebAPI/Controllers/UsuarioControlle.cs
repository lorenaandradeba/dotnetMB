using Microsoft.AspNetCore.Mvc;
using Escambo.WebAPI.Model;

namespace Escambo.WebAPI.Controllers;

[ApiController]
[Route("api/")]
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
}
