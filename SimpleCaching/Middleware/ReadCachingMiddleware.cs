using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using System.Threading.Tasks;

namespace SimpleCaching
{
    class ReadCachingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IDistributedCache cache;

        public ReadCachingMiddleware(RequestDelegate next, IDistributedCache cache)
        {
            this.next = next;
            this.cache = cache;
        }

        public async Task Invoke(HttpContext context)
        {
            var company = await cache.GetObjectAsync<CompanyInfo>("CurrentCompany");
            await context.Response.WriteAsync($"{company.Name}, {company.Email}");
        }
    }
}
