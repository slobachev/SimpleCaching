using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using System.Threading.Tasks;

namespace SimpleCaching
{
    class WriteCachingMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IDistributedCache cache;

        public WriteCachingMiddleware(RequestDelegate next, IDistributedCache cache)
        {
            this.next = next;
            this.cache = cache;
        }

        public async Task Invoke(HttpContext context)
        {
            await cache.SetObjectAsync("CurrentCompany",
                new CompanyInfo { Name = "IBM", Email = "ibm@asd.com" });
            await this.next(context);
        }
    }
}