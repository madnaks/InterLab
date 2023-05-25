using InterLab.Core.Exceptions;
using System.Net;
using System.Text.Json;

namespace InterLab.MiddleWare
{
    public class GlobalErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public GlobalErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
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
            var exceptionResult = JsonSerializer.Serialize(new { errorMessage = exception.Message, exception.StackTrace });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)GetExceptionStatusCode(exception);

            return context.Response.WriteAsync(exceptionResult);
        }

        private static HttpStatusCode GetExceptionStatusCode(Exception exception)
        {
            var statusMappings = GetStatusMappings();

            var exceptionType = exception.GetType();
            return statusMappings.TryGetValue(exceptionType, out var statusCode)
                ? statusCode
                : HttpStatusCode.InternalServerError;
        }

        private static Dictionary<Type, HttpStatusCode> GetStatusMappings()
        {
            return new Dictionary<Type, HttpStatusCode>
            {
                { typeof(BadRequestException), HttpStatusCode.BadRequest },
                { typeof(NotFoundException), HttpStatusCode.NotFound },
                { typeof(NotImplementedException), HttpStatusCode.NotImplemented },
                { typeof(UnauthorizedAccessException), HttpStatusCode.Unauthorized },
                { typeof(KeyNotFoundException), HttpStatusCode.Unauthorized },
            };
        }
    }
}
