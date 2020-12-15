using Investimentos.Infra.Cache.Exceptions;
using Investimentos.Infra.Cache.Interfaces;
using Investimentos.Infra.Cache.Providers;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Investimentos.Infra.Cache.Extensions
{
    public static class CacheManagerExtension
    {
        public static void AddCacheManager<TCacheProvider>(this IServiceCollection services)
            where TCacheProvider : ICacheProvider
        {
            services.AddMemoryCache();
            var cacheProviderType = typeof(TCacheProvider);
            var serviceProvider = services.BuildServiceProvider();
            var logger = serviceProvider.GetService<ILogger<CacheManager>>();

            if (cacheProviderType.IsAssignableFrom(typeof(IMemoryCacheProvider)))
            {
                var memoryCache = serviceProvider.GetService<IMemoryCache>();
                var memoryCacheProvider = new MemoryCacheProvider(memoryCache);
                services.AddSingleton<IMemoryCacheProvider>(imp => memoryCacheProvider);
                services.AddSingleton<ICacheManager>(imp => new CacheManager(logger, memoryCacheProvider));
                return;
            }

            throw new CacheProviderNaoImplementadoException();
        }
    }
}
