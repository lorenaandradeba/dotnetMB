using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechMed.Aplication.InputModels
{
    public class LoginInputModel
    {
        public required string Username { get; set;}
        public required string Password { get; set;}
    }
}