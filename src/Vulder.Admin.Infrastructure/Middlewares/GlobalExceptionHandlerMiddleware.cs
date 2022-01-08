using System.Net;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Vulder.Admin.Core.Exceptions;
using Vulder.Admin.Core.Models;

namespace Vulder.Admin.Infrastructure.Middlewares;

public class GlobalExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch (Exception e)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = GetStatusCode(e);

            var responseBody = new ExceptionModel
            {
                StatusCode = response.StatusCode,
                ErrorMessage = e.Message
            };

            await response.WriteAsync(JsonConvert.SerializeObject(responseBody));
        }
    }

    private static int GetStatusCode(Exception exception)
    {
        return exception switch
        {
            AuthException => (int)HttpStatusCode.Unauthorized,
            _ => (int)HttpStatusCode.InternalServerError
        };
    }
}