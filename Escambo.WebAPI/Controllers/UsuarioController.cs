

using Escambo.Application.Services.Interfaces;
using Escambo.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("Escambo/Usuario")]
public class UsuarioController : ControllerBase
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
    
}