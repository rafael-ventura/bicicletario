using System.Globalization;
using bicicletario.Application.Interfaces;
using bicicletario.Application.Services;
using bicicletario.Domain.Interfaces;
using bicicletario.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IBicicletaService, BicicletaService>();
builder.Services.AddScoped<ITotemService, TotemService>();
builder.Services.AddScoped<ITrancaService, TrancaService>();

builder.Services.AddScoped<IBicicletaRepository, BicicletaRepository>();
builder.Services.AddScoped<ITotemRepository, TotemRepository>();
builder.Services.AddScoped<ITrancaRepository, TrancaRepository>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add configuration
builder.Configuration.AddJsonFile("WebAPI/appsettings.json", optional: false, reloadOnChange: true);

// Inject the connection string so it can be used in the BicicletaRepository
var connectionString = builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTION_STRING");
if (connectionString is null)
{
    throw new InvalidOperationException(
        "A string de conexão AZURE_SQL_CONNECTIONSTRING não foi definida no appsettings.");
}

builder.Services.AddSingleton(connectionString);

var app = builder.Build();

var supportedCultures = new[] { new CultureInfo("en-US") };
var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture("en-US")
    .AddSupportedCultures(supportedCultures.ToString() ?? string.Empty)
    .AddSupportedUICultures(supportedCultures.ToString() ?? string.Empty);

app.UseRequestLocalization(localizationOptions);

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
