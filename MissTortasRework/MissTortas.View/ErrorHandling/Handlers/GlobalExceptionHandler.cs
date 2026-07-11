using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MissTortas.Services.Exceptions;
using MissTortas.View.ErrorHandling.Exceptions;

namespace MissTortas.View.Errors.Handlers
{
    public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger, IHostEnvironment environment) : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> logger = logger;
        private readonly IHostEnvironment environment = environment;

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            logger.LogError(exception, "Unhandled exception occurred");

            var problemDetails = exception switch
            {
                BusinessException bizEx => BuildFromBusinessException(bizEx, httpContext),
                _ => BuildFallback500(exception, httpContext)
            };

            problemDetails.Extensions["traceId"] = httpContext.TraceIdentifier;

            httpContext.Response.StatusCode = problemDetails.Status ?? StatusCodes.Status500InternalServerError;
            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }

        private static ProblemDetails BuildFromBusinessException(BusinessException ex, HttpContext ctx)
        {
            var (statusCode, title) = BusinessExceptionStatusMap.Resolve(ex);

            var problemDetails = new ProblemDetails
            {
                Status = statusCode,
                Title = title,
                Detail = ex.Message,
                Instance = ctx.Request.Path
            };

            if (ex.Code is not null)
                problemDetails.Extensions["code"] = ex.Code;

            foreach (var (key, value) in ex.Extensions)
                problemDetails.Extensions[key] = value;

            return problemDetails;
        }

        private ProblemDetails BuildFallback500(Exception ex, HttpContext ctx) => new()
        {
            Status = StatusCodes.Status500InternalServerError,
            Title = "An unexpected error occurred",
            Detail = environment.IsDevelopment() ? ex.Message : null,
            Instance = ctx.Request.Path
        };
    }
}
