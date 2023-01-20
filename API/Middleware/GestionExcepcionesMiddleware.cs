using System.Net;
using System.Text.Json;
using Negocio.ModelosVista;

namespace API.Middleware;

public class GestionExcepcionesMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GestionExcepcionesMiddleware> _logger;

    public GestionExcepcionesMiddleware(RequestDelegate next, ILogger<GestionExcepcionesMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await GestionarExcepcionAsync(httpContext, ex);
        }
    }

    private async Task GestionarExcepcionAsync(HttpContext context, Exception excepcion)
    {
        context.Response.ContentType = "application/json";
        var respuesta = context.Response;

        var errorResponse = new ErrorResponse
        {
            Exitoso = false
        };

        switch (excepcion)
        {
            case ApplicationException ex:
                if (ex.Message.Contains("Invalid Token"))
                {
                    respuesta.StatusCode = (int)HttpStatusCode.Forbidden;
                    errorResponse.Mensaje = ex.Message;
                    break;
                }
                respuesta.StatusCode = (int)HttpStatusCode.BadRequest;
                errorResponse.Mensaje = ex.Message;
                break;
            default:
                respuesta.StatusCode = (int)HttpStatusCode.InternalServerError;
                errorResponse.Mensaje = "Error interno del servidor!";
                break;
        }

        _logger.LogError(excepcion.Message);
        var result = JsonSerializer.Serialize(errorResponse);
        await context.Response.WriteAsync(result);
    }
}