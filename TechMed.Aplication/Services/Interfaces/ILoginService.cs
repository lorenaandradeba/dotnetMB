using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechMed.Aplication.InputModels;
using TechMed.Aplication.ViewModels;

namespace TechMed.Aplication.Services.Interfaces
{
    public interface ILoginService
    {
        public LoginViewModel? Authenticate(LoginInputModel user);
    }
}