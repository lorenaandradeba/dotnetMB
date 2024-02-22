using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ResTIConnect.Application.InputModels;
using ResTIConnect.Application.Services.Interfaces;
using ResTIConnect.Application.ViewModels;

namespace ResTIConnect.Application.Services
{
    public class LoginService : ILoginService
    {
        public LoginViewModel? Authenticate(LoginInputModel login)
        {
            throw new NotImplementedException();
        }
    }
}