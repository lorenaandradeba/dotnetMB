
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ResTIConnect.WebAPI.Controllers
{
    [ApiController]
    [Route("/api/v0.1/")]
    public class RelatoriosController : ControllerBase
    {

       
        [HttpGet("users/address/{uf}")]//  – usuários de um determinado estado 
        public IActionResult GetUsersByAddressUF(string uf)
        {
             throw new NotImplementedException();
        }
        [HttpGet("system/user/{id}")]// – sistemas com alguma relação com um determinado usuário 
        public IActionResult GetSistemasByUserId(string uf)
        {
             throw new NotImplementedException();
        }

        [HttpGet("system/event/{type}/from/{date}")]//  – sistemas onde ocorreram um determinado evento a partir de uma data até a atual 
        public IActionResult GetSistemasByEventoTipoByData(String tipo, DateTime dataInicio)
        {
             throw new NotImplementedException();
        }

    }
}