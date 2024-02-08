using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechMed.Infra.Auth
{
    public interface IAuthService
    {
        public string GenerateJwtToken(string username, string role);
        public string ComputeSha256Hash(string pass);
    }
}