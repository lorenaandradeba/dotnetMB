using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Escambo.Infra.Context;

namespace Escambo.Application.Services
{
    public abstract class BaseService
    {
        private readonly EscamboContext _context;
        public BaseService(EscamboContext context)
        {
            _context = context;
        }
    }
}