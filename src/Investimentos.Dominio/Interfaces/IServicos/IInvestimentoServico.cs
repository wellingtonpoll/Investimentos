using Investimentos.Dominio.Entities.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Investimentos.Dominio.Interfaces.IServicos
{
    public interface IInvestimentoServico
    {
        IEnumerable<Investimento> SincronizaInvestimentos();
        Task<IEnumerable<Investimento>> SincronizaFundosAsync();
        Task<IEnumerable<Investimento>> SincronizaTesouroDiretoAsync();
        Task<IEnumerable<Investimento>> SincronizaRendaFixaAsync();
    }
}