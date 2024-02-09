using TechMed.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using TechMed.Infrastructure.Interfaces;
using TechMed.Application.Service.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPacienteService, PacienteService>();


builder.Services.AddDbContext<TechMedContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("TechMed");
    var serveVersion = ServerVersion.AutoDetect(connectionString);
    options.UseMySql(connectionString, serveVersion);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
