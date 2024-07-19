using CleanArchitecture.Application.Interfaces;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using System.Text.Json;

namespace CleanArchitecture.Application
{
    public class CachingBehavior<TRequest, TResponse> (IDistributedCache cache)
        : IPipelineBehavior<TRequest, TResponse> where TRequest : ICacheableRequest
    {
        private readonly IDistributedCache cache = cache;

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var cachedItems = await cache.GetAsync(request.Key, cancellationToken);

            if (cachedItems is null)
            {
                var items = await next();

                await cache.SetAsync(request.Key, Encoding.UTF8.GetBytes(JsonSerializer.Serialize(items)),
                    new DistributedCacheEntryOptions { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10) },
                    cancellationToken
                    );

                return items;
            }

            return JsonSerializer.Deserialize<TResponse>(cachedItems);
        }
    }
}
