using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.ViewModels;

namespace ResTIConnect.WebAPI.Controllers
{

    [ApiController]
    [Route("/api/v0.1/")]
    public class EventosController : ControllerBase
    {
        private readonly IEventoService _eventoService;
        public List<EventoViewModel> Eventos => _eventoService.GetAll();
        public EventosController(IEventoService eventoService) => _eventoService = eventoService;

        [HttpGet("eventos")]
        public IActionResult Get()
        {

            return Ok(Eventos);
        }
        [HttpGet("evento/{id}")]
        public IActionResult GetById(int id)
        {
            var evento = _eventoService.GetById(id);
            return Ok(evento);
        }
        

        [HttpPost("evento")]
        public IActionResult Post([FromBody] NewEventoInputModel evento)
        {
            _eventoService.Create(evento);

            return CreatedAtAction(nameof(Get), evento);

        }

        // [HttpPut("evento/{id}")]
        // public IActionResult Put(int id, [FromBody] NewEventoInputModel evento)
        // {
        //     if (_eventoService.GetById(id) == null)
        //         return NoContent();
        //     _eventoService.Update(id, evento);
        //     return Ok(_enderecoService.GetById(id));
        // }

        // [HttpDelete("evento/{id}")]
        // public IActionResult Delete(int id)
        // {
        //     if (_eventoService.GetById(id) == null)
        //         return NoContent();
        //     _eventoService.Delete(id);
        //     return Ok();
        // }


    }
}