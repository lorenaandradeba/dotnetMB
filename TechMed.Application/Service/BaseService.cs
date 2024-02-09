namespace TechMed.Application.Services;
using TechMed.Infrastructure.Context;
using TechMed.Infrastructure.Interfaces;

public abstract class BaseService
{
   protected readonly TechMedContext _context;
   protected BaseService(TechMedContext context){
      _context = context;
   }
}