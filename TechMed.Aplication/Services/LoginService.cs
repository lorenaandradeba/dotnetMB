using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechMed.Aplication.InputModels;
using TechMed.Aplication.Services.Interfaces;
using TechMed.Aplication.ViewModels;
using TechMed.Infra.Auth;

namespace TechMed.Aplication.Services
{
    public class LoginService : ILoginService
{
   private readonly IAuthService _authService;

   public LoginService(IAuthService authService)
   {
      _authService = authService;
   }

   public LoginViewModel? Authenticate(LoginInputModel login)
   {
      //TODO: verificar se o usuario e senha coincidem e retornar o token
      var passHashed = _authService.ComputeSha256Hash(login.Password);
      if (login.Username == "admin" && passHashed == _authService.ComputeSha256Hash("admin"))
      {
         var token = _authService.GenerateJwtToken(login.Username, "admin");
         return new LoginViewModel
         {
            Username = login.Username,
            Token = token
         };
      }
      return null;
   }
}
}