
using Escambo.Application.Services;
using Escambo.Application.Services.Interfaces;
using Escambo.Infra.Context;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IAnuncioService, AnuncioService>();
// builder.Services.AddScoped<IConversaService, ConversaService>();
builder.Services.AddScoped<IMensagemService, MensagemService>();
builder.Services.AddScoped<IAvaliacaoService, AvaliacaoService>();
builder.Services.AddScoped<IPrestacaoServicoService, PrestacaoServicoService>();
 
builder.Services.AddDbContext<EscamboContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("EscamboDb");
    var serverVersion = ServerVersion.AutoDetect(connectionString);
    options.UseMySql(connectionString, serverVersion);
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
