using Common.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Common.ExceptionsHandler;

public class CustomExceptionHandler(ILogger<CustomExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        logger.LogError(exception, exception.Message);

        (string ProblemDetailsContext, int StatusCode) details = exception switch
        {
            InternalServerException => (exception.Message, StatusCodes.Status500InternalServerError),
            NotFoundException => (exception.Message, StatusCodes.Status404NotFound),
            BadRequestException => (exception.Message, StatusCodes.Status400BadRequest),
            ValidationException => (exception.Message, StatusCodes.Status400BadRequest),
            _ => (exception.Message, StatusCodes.Status500InternalServerError)
        };

        var problem = new ProblemDetails
        {
            Detail = details.ProblemDetailsContext
        };

        httpContext.Response.StatusCode = details.StatusCode;
        await httpContext.Response.WriteAsJsonAsync(problem, cancellationToken: cancellationToken);
        return true;
    }
}