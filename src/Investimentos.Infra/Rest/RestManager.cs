using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace Investimentos.Infra.Rest
{
    public class RestManager : IRestManager
    {
        private readonly ILogger<RestManager> _logger;
        public RestManager(
            ILogger<RestManager> logger)
        {
            _logger = logger;
        }

        public async Task<T> GetAsync<T>(string url) where T : class
        {
            try
            {
                var restClient = new RestClient(url);
                var request = new RestRequest(Method.GET);
                _logger.LogInformation("Realizando http request: {@Request}", request);
                var response = await restClient.ExecuteAsync(request);
                _logger.LogInformation("Response: {@Response}", response);

                return JsonConvert.DeserializeObject<T>(response.Content);
            }
            catch (Exception ex)
            {
                _logger.LogError("A requisição para a url {@Url} retornou uma exceção: {@Exception}", url, ex);
            }

            return Activator.CreateInstance<T>();
        }
    }
}
