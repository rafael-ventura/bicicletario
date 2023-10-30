using BicicletarioAPI.Application.Interfaces;
using BicicletarioAPI.Application.Services;
using BicicletarioAPI.Domain.Interfaces;
using BicicletarioAPI.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IBicicletaRepository, BicicletaRepository>();
builder.Services.AddScoped<IBicicletaService, BicicletaService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add configuration
builder.Configuration.AddJsonFile("WebAPI/appsettings.json", optional: false, reloadOnChange: true);

// Inject the connection string so it can be used in the BicicletaRepository
var connectionString = builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");
if (connectionString is null)
{
    throw new InvalidOperationException("A string de conexão AZURE_SQL_CONNECTIONSTRING não foi definida no appsettings.");
}

builder.Services.AddSingleton(connectionString);

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
