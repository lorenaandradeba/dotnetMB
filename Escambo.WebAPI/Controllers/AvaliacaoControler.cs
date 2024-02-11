using Escambo.Application.InputModels;
using Escambo.Application.Services.Interfaces;
using Escambo.Application.ViewModels;
using Escambo.WebAPI.Controllers.Interface;
using Microsoft.AspNetCore.Mvc;


namespace Escambo.WebAPI.Controllers;

[ApiController]
[Route("Escambo/")]
public class AvaliacaoController : ControllerBase, IAvaliacaoController
{
    public IActionResult Create(AvaliacaoInputModel input)
    {
        throw new NotImplementedException();
    }

    public IActionResult Delete(int id)
    {
        throw new NotImplementedException();
    }

    public IActionResult GetAll()
    {
        throw new NotImplementedException();
    }

    public IActionResult GetById(int id)
    {
        throw new NotImplementedException();
    }

    public IActionResult Update(int id, AvaliacaoInputModel input)
    {
        throw new NotImplementedException();
    }
}