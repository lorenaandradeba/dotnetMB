
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechMed.Infrastructure.Persistence;

namespace TechMed.Aplication.Services
{
    public class BaseService
    {
        protected readonly TechMedDbContext _context;
        protected BaseService(TechMedDbContext context)
        {
            _context = context;
        }
    }
}