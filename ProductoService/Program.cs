using Azure.Core;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.EntityFrameworkCore;
using NLog;
using ProductoService.CrossCuting;
using ProductoService.CrossCuting.Exceptions;
using ProductoService.DAL;
using ProductoService.Models;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
builder.Services.AddSingleton<ILoggerManager, LoggerManager>();

//Azure KeyVault
/*
SecretClientOptions options = new SecretClientOptions()
{
    Retry =
                {
                    Delay= TimeSpan.FromSeconds(2),
                    MaxDelay = TimeSpan.FromSeconds(16),
                    MaxRetries = 5,
                    Mode = RetryMode.Exponential
                 }
};
var connectionString = "Server=tcp:serverproductos.database.windows.net,1433;Initial Catalog=EquipoA;Persist Security Info=False;User ID=admin22;Password=Productos22;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;;";
// https://keyvaultteama.vault.azure.net/secrets/cadenasql/4b1f4a5b721f45d2a0bafa5838cab0db

string uri = "https://keyvaultteama.vault.azure.net/";


var client = new SecretClient(new Uri(uri), new DefaultAzureCredential(), options);
KeyVaultSecret secret = client.GetSecret("cadenasql2");

string secretValue = secret.Value;

builder.Services.AddDbContext<ProductoContext>(options => options.UseSqlServer(connectionString));
*/


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<ProductoContext>();

builder.Services.AddScoped<IProductoProvider, ProductoProviderEF>();
//builder.Services.AddScoped<IProductoProvider, ProductoProviderFake>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionMiddleware();
}

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
