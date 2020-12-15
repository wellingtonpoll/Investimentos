using Investimentos.Infra.Cache.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Investimentos.Infra.Cache
{
    public class CacheManager : ICacheManager
    {
        private readonly ILogger<CacheManager> _logger;
        private readonly ICacheProvider _cacheProvider;
        public CacheManager(
            ILogger<CacheManager> logger,
            ICacheProvider cacheProvider)
        {
            _cacheProvider = cacheProvider;
            _logger = logger;
        }

        public async Task<TObject> ReadAsync<TObject>(string key) where TObject : class
        {
            try
            {
                var obj = await _cacheProvider.ReadAsync<TObject>(key);
                _logger.LogInformation("Leitura da chave {@CacheKey} no cache: {@CacheValue}", key, obj);
                return obj;
            }
            catch (Exception ex)
            {
                _logger.LogError("Falha ao obter dados do cache {@CacheKey} - Exception: {@Exception}", key, ex);
            }

            return null;
        }
        public async Task WriteAsync<TObject>(TObject obj, string key, TimeSpan lifeSpan) where TObject : class
        {
            try
            {
                await _cacheProvider.WriteAsync(obj, key, lifeSpan);
                _logger.LogInformation("Persistência da chave {@CacheKey} no cache: {@CacheValue}", key, obj);
            }
            catch (Exception ex)
            {
                _logger.LogError("Falha ao persistir dados no cache {@CacheKey}:{@CacheValue} - Exception: {@Exception}", key, obj, ex);
            }
        }
        public TimeSpan NextDay0Hours()
        {
            return TimeSpan.FromHours(DateTime.Today.AddDays(1).Subtract(DateTime.Now).TotalHours);
        }
    }
}
