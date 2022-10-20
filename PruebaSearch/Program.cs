using Polly;
using Polly.CircuitBreaker;
using Polly.Retry;
using PruebaSearch;
using PruebaSearch.Interfaces;
using PruebaSearch.Services;
using System;
using System.Net.Http;

var builder = WebApplication.CreateBuilder(args);

//Configuración para el ejercicio
ConfigurationManager Configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductosService, ProductosService>();
builder.Services.AddScoped<IProveedoresService, ProveedoresService>();
builder.Services.AddScoped<IComprasService, ComprasService>();


Action<Exception, TimeSpan> onBreak = (exception, timespan) => {
    Console.WriteLine("Conexion rota");
    Console.WriteLine($"Tipo de excepcion : {exception.Message}");        
};

Action onReset = () => {
    Console.WriteLine("Reseteando el intento de conexion"); 
};

//privado solo lectura RetryPolicy _retryPolicy;

//Remaining Code has been removed for readability

        builder.Services.AddHttpClient("proveedoresService", c =>
        {
            
            c.BaseAddress = new Uri(Configuration["Services:Proveedores"]);
            Console.WriteLine("reintento");
        });
   


//builder.Services.AddHttpClient("proveedoresService", c =>
//            {
//                c.BaseAddress = new Uri(Configuration["Services:Proveedores"]);

//            });


var breakerProductos = await Policy
    .Handle<Exception>()
    .CircuitBreakerAsync(2, TimeSpan.FromMinutes(1), onBreak, onReset)
    .ExecuteAndCaptureAsync(async () =>
    {
            
        builder.Services.AddHttpClient("productosService", c =>
        {
            c.BaseAddress = new Uri(Configuration["Services:Productos"]);

        });
           
    });

var breakerCompras = await Policy
    .Handle<Exception>()
    .CircuitBreakerAsync(2, TimeSpan.FromMinutes(1), onBreak, onReset)
    .ExecuteAndCaptureAsync(async () =>
        {
                
            builder.Services.AddHttpClient("comprasService", c =>
            {
                c.BaseAddress = new Uri(Configuration["Services:Compras"]);

            });
        });





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.UseGlobalExceptionMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

//prueba3