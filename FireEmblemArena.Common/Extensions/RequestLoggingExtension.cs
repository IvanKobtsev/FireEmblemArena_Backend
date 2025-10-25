using FireEmblemArena.Common.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace FireEmblemArena.Common.Extensions;

public static class RequestLoggingExtension
{
    public static IApplicationBuilder UseRequestLoggingMiddleware(this IApplicationBuilder app)
    {
        return app.UseMiddleware<RequestLoggingMiddleware>();
    }
}