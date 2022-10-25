namespace ProductoService.CrossCuting.Exceptions
{
    public class ExceptionMiddleware
    {

        private readonly RequestDelegate _next;
        private readonly ILoggerManager _loggerManager;
        public ExceptionMiddleware(RequestDelegate next, ILoggerManager loggerManager)
        {
            _next = next;
            _loggerManager = loggerManager;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"excepcion en el lanzamiento de excepciones: {ex.ToString()}");
                //Add logging code to log exception details
                httpContext.Response.Redirect("/");
            }
        }
    }
}
