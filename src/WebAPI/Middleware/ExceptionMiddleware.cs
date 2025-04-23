using System.Text.Json;
using WebShopAPI.Domain.Exceptions;

namespace WebShopAPI.WebAPI.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
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
            _logger.LogError(ex, "Ocorreu um erro durante o processamento da solicitação.");
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        if (exception is ValidacaoDominioException validacaoException)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;

            var result = JsonSerializer.Serialize(new
            {
                message = "Erro de validação de domínio",
                errors = validacaoException.Erros.Select(e => new { e.Propriedade, e.Mensagem })
            });

            return context.Response.WriteAsync(result);
        }

        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        var genericResult = JsonSerializer.Serialize(new { message = "Erro interno no servidor." });
        return context.Response.WriteAsync(genericResult);
    }
}
