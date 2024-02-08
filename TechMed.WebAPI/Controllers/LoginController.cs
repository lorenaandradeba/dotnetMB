using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechMed.Aplication.InputModels;
using TechMed.Aplication.Services.Interfaces;

namespace TechMed.WebAPI.Controllers
{
    [ApiController]
    [Route("/api/v0.1/")]
     public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private LoginController(ILoginService loginService) => _loginService = loginService;

        [HttpPost]
        public IActionResult Login([FromBody] LoginInputModel user)
        {
            var userViewModel = _loginService.Authenticate(user);
            if (userViewModel is not null)
            {
                return Ok(userViewModel);
            }
            return Unauthorized();
        }
    }
}