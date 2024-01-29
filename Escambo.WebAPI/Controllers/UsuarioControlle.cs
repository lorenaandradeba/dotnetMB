using Microsoft.AspNetCore.Mvc;
using Escambo.WebAPI.Model;
using System.Security.Cryptography.X509Certificates;

namespace Escambo.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class UsuarioController : ControllerBase
{

    List<Usuario> usuarios = new List<Usuario>();  
    
    [HttpGet] 
    [Route("usuario/{id}")]

    public IActionResult Get(int id)
    {
      var usuario = usuarios.FirstOrDefault(u => u.UsuarioId == id);
      if (usuario == null){
        return NoContent();
      }else{
          return Ok(usuario.ToString());
      }
    }

    [HttpGet]
    [Route("usuarios")]
    public IActionResult GetAll(int id)
    {
       
        return Ok(usuarios.ToString());
    }

    [HttpPost]
    [Route("usuario/cadastro")]
    public IActionResult Post([FromBody] Usuario novousuario){
        
        var usuario = usuarios.FirstOrDefault(u => u.CPF == novousuario.CPF);
        if (usuario == null){
            usuarios.Add(novousuario);
            return Ok();
        }else{
            return BadRequest();
        }
    }

    [HttpDelete]
    [Route("usuario/{id}")]
    public IActionResult Delete(int id)
    {
        var usuario = usuarios.FirstOrDefault(u => u.UsuarioId == id);
        if (usuario == null){

            return NotFound();
        }else
        {
            usuarios.Remove(usuario);
            return Ok();
        }
       
    }

    [HttpPut]
    [Route("usuario/{id}")]
    public IActionResult Put(int id, [FromBody] Usuario usuario)
    {
        var usuarioExistente = usuarios.FirstOrDefault(u => u.CPF == usuario.CPF);
        if (usuarioExistente == null){
            return NotFound();
        }else{
            var index = usuarios.IndexOf(usuarioExistente);
            usuarios[index] = usuario;
            return Ok();
        }
    }

}
