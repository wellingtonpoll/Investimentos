using System;
using System.Threading.Tasks;

namespace Investimentos.Infra.Cache.Interfaces
{
    public interface ICacheProvider
    {
        Task<TObject> ReadAsync<TObject>(string key) where TObject : class;
        Task WriteAsync<TObject>(TObject obj, string key, TimeSpan lifeSpan) where TObject : class;
    }
}
