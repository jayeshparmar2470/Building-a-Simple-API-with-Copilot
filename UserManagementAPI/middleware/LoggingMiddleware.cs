namespace UserManagementAPI.Middleware
{
    using Microsoft.AspNetCore.Http;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;

    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Log the request details
            _logger.LogInformation("HTTP Request: {method} {path}", context.Request.Method, context.Request.Path);

            await _next(context);

            // Log the response details
            _logger.LogInformation("HTTP Response: {statusCode}", context.Response.StatusCode);
        }
    }
}