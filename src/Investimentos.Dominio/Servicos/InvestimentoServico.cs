using Investimentos.Dominio.Entities;
using Investimentos.Dominio.Entities.Base;
using Investimentos.Dominio.Interfaces.IServicos;
using Investimentos.Dominio.Models;
using Investimentos.Dominio.Options;
using Investimentos.Infra.Cache;
using Investimentos.Infra.Cache.Interfaces;
using Investimentos.Infra.Rest;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Investimentos.Dominio.Servicos
{
    public class InvestimentoServico : IInvestimentoServico
    {
        
        private readonly IRestManager _restManager;
        private readonly ICacheManager _cacheManager;
        private readonly ILogger<InvestimentoServico> _logger;
        private readonly ServicosExternosOptions _servicosExternosOptions;
        
        public InvestimentoServico(
            IRestManager restManager,
            ICacheManager cacheManager,
            ILogger<InvestimentoServico> logger,
            IOptions<ServicosExternosOptions> servicosExternosOptions)
        {
            _logger = logger;
            _restManager = restManager;
            _cacheManager = cacheManager;
            _servicosExternosOptions = servicosExternosOptions.Value;
        }

        public IEnumerable<Investimento> SincronizaInvestimentos()
        {
            // Obtém os dados do cache
            var investimentosNoCache = _cacheManager.ReadAsync<IEnumerable<Investimento>>(CacheKey.InvestimentoConsolidado()).Result;
            if (investimentosNoCache != null)
                return investimentosNoCache;

            // Se os dados não estiverem cache realiza a sincronização com as APIs externas
            var investimentos = new List<Investimento>();
            var taskFundos = SincronizaFundosAsync();
            var taskRendaFixa = SincronizaRendaFixaAsync();
            var taskTesouroDireto = SincronizaTesouroDiretoAsync();

            // Espera todas as tarefas de sincronização finalizarem
            Task.WaitAll(taskFundos, taskRendaFixa, taskTesouroDireto);

            // Unifica todos os investimentos
            investimentos.AddRange(taskFundos.Result);
            investimentos.AddRange(taskRendaFixa.Result);
            investimentos.AddRange(taskTesouroDireto.Result);

            // Armazena os dados sincronizados no cache
            // var tempoDeVidaNoCache = _cacheManager.NextDay0Hours();
            var tempoDeVidaNoCache = TimeSpan.FromSeconds(10);
            _cacheManager.WriteAsync(investimentos, CacheKey.InvestimentoConsolidado(), tempoDeVidaNoCache);

            // Retorna os investimentos consolidados
            return investimentos;
        }

        public async Task<IEnumerable<Investimento>> SincronizaFundosAsync()
        {
            IEnumerable<Fundo> investimentos = new List<Fundo>();
            try
            {
                var responseModel = await _restManager.GetAsync<ColecaoFundoModel>(_servicosExternosOptions.UrlFundo);
                return responseModel.Fundos.Select(fundoModel => fundoModel.ConverteParaEntidade());
            }
            catch (Exception ex)
            {
                _logger.LogError("Falha na execução da sincronização de fundos de investimentos. Detalhes: {@Exception}", ex);
            }
            return investimentos;
        }
        public async Task<IEnumerable<Investimento>> SincronizaRendaFixaAsync()
        {
            IEnumerable<RendaFixa> investimentos = new List<RendaFixa>();
            try
            {
                var responseModel = await _restManager.GetAsync<ColecaoRendaFixaModel>(_servicosExternosOptions.UrlRendaFixa);
                return responseModel.Lcis.Select(redaFixaModel => redaFixaModel.ConverteParaEntidade());
            }
            catch (Exception ex)
            {
                _logger.LogError("Falha na execução da sincronização da renda fixa. Detalhes: {@Exception}", ex);
            }
            return investimentos;
        }
        public async Task<IEnumerable<Investimento>> SincronizaTesouroDiretoAsync()
        {
            IEnumerable<TesouroDireto> investimentos = new List<TesouroDireto>();
            try
            {
                var responseModel = await _restManager.GetAsync<ColecaoTesouroDiretoModel>(_servicosExternosOptions.UrlTesouroDireto);
                return responseModel.Tds.Select(tesouroDiretoModel => tesouroDiretoModel.ConverteParaEntidade());
            }
            catch (Exception ex)
            {
                _logger.LogError("Falha na execução da sincronização do tesouro diret. Detalhes: {@Exception}", ex);
            }
            return investimentos;
        }
    }
}
