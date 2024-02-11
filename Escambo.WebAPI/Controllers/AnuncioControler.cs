using Escambo.Application.InputModels;
using Escambo.Application.Services.Interfaces;
using Escambo.Application.ViewModels;
using Escambo.WebAPI.Controllers.Interface;
using Microsoft.AspNetCore.Mvc;


namespace Escambo.WebAPI.Controllers
{
    [ApiController]
    [Route("Escambo/")]
    public class AnuncioControler : ControllerBase, IAnuncioController
    {
        protected readonly IAnuncioService _anuncioService;
        public List<AnuncioViewModel> _anuncios => _anuncioService.GetAll().ToList();
        public AnuncioControler(IAnuncioService anuncioService) => _anuncioService = anuncioService;

        [HttpPost("Anuncio")]
        public IActionResult Create(AnuncioInputModel input)
        {
           var id = _anuncioService.Create(input);
           if(id == 0) return BadRequest();
           return Ok(id);
        }

        [HttpDelete("Anuncio/{id}")]
        public IActionResult Delete(int id)
        {
            
            _anuncioService.Delete(id);
            return Ok();

        }

        [HttpGet("Anuncio/all")]

        public IActionResult GetAll()
        {
            if(_anuncios is not null) return Ok(_anuncios);
            return NotFound();
        }
        [HttpGet("Anuncio/{id}")]
        public IActionResult GetById(int id)
        {
            var anuncio = _anuncioService.GetById(id);
            if(anuncio is not null) return Ok(anuncio);

            return NotFound();
        }
        [HttpPut("Anuncio/{id}")]   
        public IActionResult Update(int id, AnuncioInputModel input)
        {
            if(_anuncioService.GetById(id) is null) return NotFound();
            _anuncioService.Update(id, input);
            return Ok();
        }
    }
}