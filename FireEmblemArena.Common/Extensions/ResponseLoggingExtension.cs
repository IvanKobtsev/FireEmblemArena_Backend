using FireEmblemArena.Common.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace FireEmblemArena.Common.Extensions;

public static class ResponseLoggingExtension
{
    public static IApplicationBuilder UseResponseLoggingMiddleware(this IApplicationBuilder app)
    {
        return app.UseMiddleware<ResponseLoggingMiddleware>();
    }
}