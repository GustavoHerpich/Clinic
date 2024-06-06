using Clinic.Exceptions;
using System.Net;

namespace Clinic.Middleware
{
    public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        private readonly RequestDelegate _next = next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger = logger;
        public record ExceptionResponse(HttpStatusCode StatusCode, string Description);

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
            _logger.LogError(exception, "Mensagem de erro do servidor {ErrorMessage}", exception.Message);

            ExceptionResponse response = exception switch
            {
                NotFoundException notFoundEx => new ExceptionResponse(HttpStatusCode.NotFound, notFoundEx.Message),
                UnauthorizedException _ => new ExceptionResponse(HttpStatusCode.Unauthorized, "Usuário ou senha inválidos."),
                BadRequestException badRequestEx => new ExceptionResponse(HttpStatusCode.BadRequest, badRequestEx.Message),
                _ => new ExceptionResponse(HttpStatusCode.InternalServerError, "Ocorreu um erro no nosso sistema, favor entre em contato com nós ou tente mais tarde.")
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)response.StatusCode;
            await context.Response.WriteAsJsonAsync(response);
        }
    }
}