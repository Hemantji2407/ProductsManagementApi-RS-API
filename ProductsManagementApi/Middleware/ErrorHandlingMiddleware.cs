using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProductsManagementApi.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred.");

                // Set appropriate HTTP status code based on the exception type
                var statusCode = StatusCodes.Status500InternalServerError;

                // Customize error response based on the exception type
                var response = new { message = "An error occurred." };
                if (ex is UnauthorizedAccessException)
                {
                    statusCode = StatusCodes.Status401Unauthorized;
                    response = new { message = "Unauthorized access." };
                }
                else if (ex is FileNotFoundException)
                {
                    statusCode = StatusCodes.Status404NotFound;
                    response = new { message = "Resource not found." };
                }

                // Set response details
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = statusCode;
                await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            }
        }
    }
}
