using Microsoft.AspNetCore.Diagnostics;
using MSG.Application.Common.Exceptions;
using System.Net;
using System.Text.Json;

namespace MSG.WebApi.Extensions;

public static class ErrorHandlerExtensions
{
    public static void UseErrorHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature == null) return;

                context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                context.Response.ContentType = "application/json";

                string[] errors = new string[] { };

                switch (contextFeature.Error)
                {
                    case BadRequestException exception:
                        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        errors = exception.Errors;
                        break;
                    case OperationCanceledException:
                        context.Response.StatusCode = (int)HttpStatusCode.ServiceUnavailable;
                        break;
                    case NotFoundException:
                        context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var errorResponse = new
                {
                    statusCode = context.Response.StatusCode,
                    message = contextFeature.Error.GetBaseException().Message,
                    details = errors.Any() ? errors : new string[] {}
                };

                await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
            });
        });
    }
}