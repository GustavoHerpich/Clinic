using System.Net;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;
    public record ExceptionResponse(HttpStatusCode StatusCode, string Description);


    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        _logger.LogError(exception, "An unexpected error occurred.");


        ExceptionResponse response = exception switch
        {
            KeyNotFoundException _ => new ExceptionResponse(HttpStatusCode.NotFound, "Funcionário não encontrado."),
            UnauthorizedAccessException _ => new ExceptionResponse(HttpStatusCode.Unauthorized, "Usuário ou senha inválidos."),
            _ => new ExceptionResponse(HttpStatusCode.InternalServerError, "Ocorreu um erro no nosso sistema, favor entre em contato com nós ou tente mais tarde.")
        };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)response.StatusCode;
        await context.Response.WriteAsJsonAsync(response);
    }
}