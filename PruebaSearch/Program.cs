using Polly;
using Polly.Extensions.Http;
using PruebaSearch;
using PruebaSearch.Interfaces;
using PruebaSearch.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        //Configuración para el ejercicio
        ConfigurationManager Configuration = builder.Configuration;

        // Add services to the container.
        builder.Services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        //Inyección de dependencias remotas
        builder.Services.AddScoped<IProductosService, ProductosService>();
        builder.Services.AddScoped<IProveedoresService, ProveedoresService>();
        builder.Services.AddScoped<IComprasService, ComprasService>();


        //PROVEEDORES, HttpClient
        builder.Services.AddHttpClient("proveedoresService", c =>
        {
            c.BaseAddress = new Uri(Configuration["Services:Proveedores"]);

        }).SetHandlerLifetime(TimeSpan.FromSeconds(2))  //Set lifetime to five seconds
            .AddPolicyHandler(GetRetryPolicy());


        //PRODUCTOS, HttpClient
        builder.Services.AddHttpClient("productosService", c =>
        {
            c.BaseAddress = new Uri(Configuration["Services:Productos"]);

        }).SetHandlerLifetime(TimeSpan.FromSeconds(2))  //Set lifetime to five seconds
            .AddPolicyHandler(GetRetryPolicy());


        //COMPRAS, HttpClient
        builder.Services.AddHttpClient("comprasService", c =>
        {
            c.BaseAddress = new Uri(Configuration["Services:Compras"]);

        }).SetHandlerLifetime(TimeSpan.FromSeconds(2))  //Set lifetime to five seconds
            .AddPolicyHandler(GetRetryPolicy()); ;


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        
        //esto de abajo que pasa ?? ?? ?? 

        //app.UseGlobalExceptionMiddleware();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }

    static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
    {
        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
            .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2,
                                                                        retryAttempt)));
    }
}