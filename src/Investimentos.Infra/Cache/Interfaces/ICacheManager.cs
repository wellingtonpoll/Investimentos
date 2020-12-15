using System;
using System.Threading.Tasks;

namespace Investimentos.Infra.Cache.Interfaces
{
    public interface ICacheManager
    {
        Task<TObject> ReadAsync<TObject>(string key) where TObject : class;
        Task WriteAsync<TObject>(TObject obj, string key, TimeSpan lifeSpan) where TObject : class;
        TimeSpan NextDay0Hours();
    }
}
