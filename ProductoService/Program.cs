using NLog;
using ProductoService.CrossCuting;
using ProductoService.CrossCuting.Exceptions;
using ProductoService.DAL;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
builder.Services.AddSingleton<ILoggerManager, LoggerManager>();


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
