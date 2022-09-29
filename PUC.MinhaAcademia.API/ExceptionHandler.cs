using PUC.MinhaAcademiaPlus.Domain.DTO;
using PUC.MinhaAcademiaPlus.Domain.Exceptions;
using PUC.MinhaAcademiaPlus.Domain.Utils;

namespace PUC.MinhaAcademiaPlus.API
{
    public static class ExceptionHandler
    {
        public static WebApplication UseExceptionHandler(this WebApplication app)
        {
            app.UseExceptionHandler(exceptionHandlerApp =>
            {
                exceptionHandlerApp.Run(async context =>
                {
                    IExceptionHandlerPathFeature? errorDetails = context.Features.Get<IExceptionHandlerPathFeature>();

                    if (errorDetails?.Error is ArgumentException || errorDetails?.Error is ArgumentNullException)
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    else if (errorDetails?.Error is SemAutorizacaoException)
                        context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    else
                        context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                    context.Response.ContentType = "application/json";

                    Erro result = new();
                    result.StatusCode = context.Response.StatusCode;
                    result.Message = errorDetails?.Error.Message ?? string.Empty;
                    result.InnerMessage = errorDetails?.Error.InnerException?.Message ?? string.Empty;

                    await context.Response.WriteAsync(Util.SerializarJson(result));
                });
            });

            return app;
        }
    }
}