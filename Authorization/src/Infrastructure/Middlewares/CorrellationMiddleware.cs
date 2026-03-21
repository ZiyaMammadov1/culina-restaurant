namespace AuthService.Infrastructure.Middlewares
{
    public class CorrellationMiddleware
    {
        private readonly RequestDelegate _next;

        public CorrellationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue("X-Correlation-Id", out var cid))
                cid = Guid.NewGuid().ToString();

            //context.TraceIdentifier = cid;
            context.TraceIdentifier = cid!;

            //context.Response.Headers.Add("X-Correlation-Id", cid);
            context.Response.Headers.TryAdd("X-Correlation-Id", cid);

            using (Serilog.Context.LogContext.PushProperty("CorrelationId", cid))
            {
                await _next(context);
            }

        }
    }
}
