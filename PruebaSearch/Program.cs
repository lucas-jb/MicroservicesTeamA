using PruebaSearch.Interfaces;
using PruebaSearch.Services;

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

builder.Services.AddHttpClient("proveedoresService", c =>
{
    c.BaseAddress = new Uri(Configuration["Services:Proveedores"]);

});

builder.Services.AddHttpClient("productosService", c =>
{
    c.BaseAddress = new Uri(Configuration["Services:Productos"]);

});

builder.Services.AddHttpClient("comprasService", c =>
{
    c.BaseAddress = new Uri(Configuration["Services:Compras"]);

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

//prueba3