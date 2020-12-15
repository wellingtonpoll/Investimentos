using Investimentos.Infra.Cache.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Threading.Tasks;

namespace Investimentos.Infra.Cache.Providers
{
    public class MemoryCacheProvider : IMemoryCacheProvider
    {
        private readonly IMemoryCache _memoryCache;
        public MemoryCacheProvider(IMemoryCache memoryCache)
        {
            if (memoryCache == null)
                throw new ArgumentNullException("Para inicializar a classe MemoryCacheProvider uma instância de IMemoryCache é necessária!");

            _memoryCache = memoryCache;
        }

        public async Task<TObject> ReadAsync<TObject>(string key) where TObject : class
        {
            _memoryCache.TryGetValue(key, out TObject caheValue);
            return await Task.FromResult(caheValue);
        }

        public async Task WriteAsync<TObject>(TObject obj, string key, TimeSpan lifeSpan) where TObject : class
        {
            await Task.FromResult(_memoryCache.Set(key, obj, lifeSpan));
        }
    }
}
