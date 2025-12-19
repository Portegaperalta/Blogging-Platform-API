namespace Blogging_Platform_API.Middleware
{
    public class LogRequestMiddleware
    {
        private readonly RequestDelegate next;
        public LogRequestMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var logger = context.RequestServices. GetRequiredService<ILogger<Program>>();
            logger.LogInformation($"Request: {context.Request} {context.Request.Path}");

            await next.Invoke(context);

            logger.LogInformation($"Response: {context.Response} {context.Response.StatusCode}");
        }
    }

    public static class LogRequestMiddlewareExtensions
    {
        public static IApplicationBuilder UseLogRequest(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LogRequestMiddleware>();
        }
    }
}
