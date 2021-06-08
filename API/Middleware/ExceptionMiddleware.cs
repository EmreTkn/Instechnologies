using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using API.Errors;
using Microsoft.AspNetCore.Http;

namespace API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context) //Returns the error to the client when unexpected error occurs.
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 500;

                if (e.StackTrace != null)
                {
                    var response = new ApiException(500, e.Message,
                        e.StackTrace);
                   
                    var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

                    var json = JsonSerializer.Serialize(response, options);

                    await context.Response.WriteAsync(json);
                }
            }
        }
    }
}
