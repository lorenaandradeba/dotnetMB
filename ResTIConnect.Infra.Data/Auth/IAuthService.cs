using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResTIConnect.Infra.Data.Auth
{
    public interface IAuthService
    {
        string GenerateJwtToken(string email, string role); 
    }
}