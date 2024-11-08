using Newtonsoft.Json;
using System.Net;

namespace SmartBlendHub.WebApi.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
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

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected
            if (exception is UnauthorizedAccessException) code = HttpStatusCode.Unauthorized;
            // You can add more exception types to handle here
            var result = JsonConvert.SerializeObject(new { error = exception.Message });
            context.Response.ContentType = "application/json"; context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
