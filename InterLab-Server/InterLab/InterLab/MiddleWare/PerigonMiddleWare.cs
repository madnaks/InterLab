namespace InterLab.MiddleWare
{
    public class PerigonMiddleWare
    {
        private readonly RequestDelegate _next;
        private const string APIKEY = "ApiKey";

        public PerigonMiddleWare(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            await _next(httpContext);
        }
    }
}
