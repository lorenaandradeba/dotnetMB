

using Escambo.Application.InputModels;
using Escambo.Application.Services.Interfaces;
using Escambo.Application.ViewModels;
using Escambo.WebAPI.Controllers.Interface;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("Escambo/Usuario")]
public class UsuarioController : ControllerBase, IUsuarioController
{
    protected readonly IUsuarioService _usuarioService;
    public List<UsuarioViewModel> _usuarios  => _usuarioService.GetAll().ToList();

    public UsuarioController(IUsuarioService usuarioService) => _usuarioService = usuarioService;
    [HttpGet]
    public IActionResult GetAll()
    {
        if(_usuarios == null) return NotFound();

        return Ok(_usuarios); 
    }

    public IActionResult Create(UsuarioInputModel input)
    {
       var id =  _usuarioService.Create(input);
       if(id == 0) return BadRequest();
       return Ok(id);
    }

    public IActionResult GetById(int id)
    {
        var _usuarios = _usuarioService.GetById(id);
        if(_usuarios is not null)  return Ok(_usuarios);
        
        return NotFound();
       
    }

    public IActionResult Update(int id, UsuarioInputModel input)
    {
        _usuarioService.Update(id, input);
        return Ok();
    }


    public IActionResult Delete(int id)
    {
        _usuarioService.Delete(id);
        return Ok();
    }
}