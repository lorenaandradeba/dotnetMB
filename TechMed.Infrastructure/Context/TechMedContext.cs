using Microsoft.EntityFrameworkCore;

namespace TechMed.Infrastructure.Context;


public class TechMedContext : DbContext
{
    public TechMedContext(DbContextOptions<TechMedContext> options) : base(options){}
}