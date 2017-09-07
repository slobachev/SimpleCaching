using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCaching
{
    public static class UseMiddlewareExtensions
    {
        public static IApplicationBuilder UseWriteCaching(this IApplicationBuilder app) =>
            app.UseMiddleware<WriteCachingMiddleware>();

        public static IApplicationBuilder UseReadCaching(this IApplicationBuilder app) =>
            app.UseMiddleware<ReadCachingMiddleware>();


    }
}
