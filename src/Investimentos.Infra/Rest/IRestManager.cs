using System.Threading.Tasks;

namespace Investimentos.Infra.Rest
{
    public interface IRestManager
    {
        Task<T> GetAsync<T>(string url) where T : class;
    }
}
