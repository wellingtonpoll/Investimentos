using Investimentos.Dominio.Entities;
using Investimentos.Infra.Cache.Interfaces;
using Investimentos.Teste.Base;
using Moq;
using Xunit;
using AutoFixture;
using System.Threading.Tasks;
using Investimentos.Infra.Cache;
using Microsoft.Extensions.Logging;
using System;
using Investimentos.Infra.Cache.Providers;

namespace Investimentos.Teste
{
    public class CacheManagerTeste : BaseTeste
    {
        private readonly Mock<ILogger<CacheManager>> _mockLogger;
        private readonly Mock<ICacheProvider> _mockCacheProvider;

        public CacheManagerTeste()
        {
            _mockLogger = new Mock<ILogger<CacheManager>>();
            _mockCacheProvider = new Mock<ICacheProvider>();
        }

        [Fact(DisplayName = "READ - Recupera valor do cache")]
        [Trait("Categoria", "CACHE MANAGER")]
        public void Cache_Manager_Recupera_Valor()
        {
            //Given
            var key = _fixture.Create<string>();
            var valorCacheEsperado = _fixture.Create<TesouroDireto>();
            var cacheManager = new CacheManager(_mockLogger.Object, _mockCacheProvider.Object);
            _mockCacheProvider.Setup(c => c.ReadAsync<TesouroDireto>(It.IsAny<string>())).Returns(Task.FromResult(valorCacheEsperado));

            //When
            var valorCache = cacheManager.ReadAsync<TesouroDireto>(key).GetAwaiter().GetResult();

            //Then
            Assert.Equal(valorCacheEsperado, valorCache);
        }

        [Fact(DisplayName = "WRITE - Persiste valor no cache")]
        [Trait("Categoria", "CACHE MANAGER")]
        public void Cache_Manager_Persiste_Valor()
        {
            //Given
            var key = _fixture.Create<string>();
            var cacheLifespan = _fixture.Create<TimeSpan>();
            var tesouroDireto = _fixture.Create<TesouroDireto>();
            var cacheManager = new CacheManager(_mockLogger.Object, _mockCacheProvider.Object);
            _mockCacheProvider.Setup(c => c.WriteAsync(
                It.IsAny<TesouroDireto>(),
                It.IsAny<string>(),
                It.IsAny<TimeSpan>()))
                    .Returns(Task.CompletedTask);

            //When
            var task = cacheManager.WriteAsync(tesouroDireto, key, cacheLifespan);

            //Then
            Assert.True(task.IsCompleted);
        }

        [Fact(DisplayName = "MEMORY CACHE PROVIDER - Não inicializa sem uma instância de IMemoryCache")]
        [Trait("Categoria", "CACHE MANAGER")]
        public void MemoryCacheProvider_Nao_Inicializa_Sem_IMemoryCache()
        {
            //Given
            //When
            //Then
            Assert.Throws<ArgumentNullException>(() => new MemoryCacheProvider(null));
        }

        [Fact(DisplayName = "NEXT DAY 0 HOUR - Obtém timespan relativo a data corrente até o dia seguinte 00:00")]
        [Trait("Categoria", "CACHE MANAGER")]
        public void Cache_Manager_Next_Day_0_Hour()
        {
            //Given
            var cacheManager = new CacheManager(_mockLogger.Object, _mockCacheProvider.Object);
            var timeSpanEsperado = TimeSpan.FromHours(DateTime.Today.AddDays(1).Subtract(DateTime.Now).TotalHours);

            //When
            var timespanNextDay0Hours = cacheManager.NextDay0Hours();
            var diferenca = Math.Truncate(timespanNextDay0Hours.Subtract(timeSpanEsperado).TotalMinutes);

            //Then
            Assert.Equal(0, diferenca);
        }
    }
}
