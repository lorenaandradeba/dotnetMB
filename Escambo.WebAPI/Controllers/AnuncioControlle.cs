using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Escambo.WebAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace Escambo.WebAPI.Controllers;

[ApiController]
[Route("/api/v0.1/")]
public class AnuncioControlle : ControllerBase
{

    [HttpGet]
    [Route("anuncio/{id}")]
    public IActionResult Get(int id)
    {
        var usuario = new Usuario
        {
            UsuarioId = 1,
            Nome = "Usuario 1"
        };
        var anuncios = Enumerable.Range(1, 5).Select(index => new Anuncio
        {
            AnuncioId = index,
            Nome = $"Anuncio do Serviço {index}", 
            Usuario = usuario
        })
          .ToArray();
        return Ok(anuncios);
    }
    [HttpGet]
    [Route("anuncios")]
    public IActionResult GetAtendimento(int id)
    {
        var usuario = new Usuario
        {
            UsuarioId = 1,
            Nome = "Usuario 1"
        };
        var anuncio =  new Anuncio
        {
            AnuncioId = id,
            Nome = $"Anuncio do Serviço {id}", 
            Usuario = usuario
        };
      return Ok(anuncio);
   }
    [HttpPost]
    [Route("anuncio/cadastro")]
    public IActionResult Post([FromBody] Anuncio anuncio)
    {
        return Ok(anuncio.ToString());
    }
}