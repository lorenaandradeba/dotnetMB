using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Auth
{
    public interface IAuthService
    {
        string GenerateJwtToken(string email, string role); 
    }
}