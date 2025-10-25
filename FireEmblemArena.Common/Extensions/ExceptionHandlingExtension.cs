using FireEmblemArena.Common.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace FireEmblemArena.Common.Extensions;

public static class ExceptionHandlingExtensions
{
    public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder app)
    {
        return app.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}