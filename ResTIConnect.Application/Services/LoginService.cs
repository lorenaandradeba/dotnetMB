using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.ViewModels;
using ResTIConnect.Infra.Data.Auth;

namespace ResTIConnect.Application.Services
{
    public class LoginService : ILoginService
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;
        public LoginService(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }
        public LoginViewModel? Authenticate(LoginInputModel login)
        {
            string _token = "";

            if (_userService.AutenticateUser(login.Email, login.Password)){
                 bool isAdmin = _userService.IsUserAdmin(login.Email);
                 _token = _authService.GenerateJwtToken(login.Email, isAdmin ? "Admin" : "User");
            }
                  

            if (_token != "")
            {
                return new LoginViewModel
                {
                    Username = login.Email,
                    Token = _token
                };
            }
            return null;
        }
    }
}