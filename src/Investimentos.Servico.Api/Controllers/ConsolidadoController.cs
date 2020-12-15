using AutoMapper;
using Investimentos.Dominio.Interfaces.IServicos;
using Investimentos.Servico.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Investimentos.Servico.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsolidadoController : ControllerBase
    {
        private readonly ILogger<ConsolidadoController> _logger;
        private readonly IInvestimentoServico _investimentoServico;
        private readonly IMapper _mapper;
        public ConsolidadoController(
            ILogger<ConsolidadoController> logger,
            IInvestimentoServico investimentoServico,
            IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _investimentoServico = investimentoServico;
        }

        [HttpGet]
        public IActionResult Lista()
        {
            _logger.LogInformation("Iniciando listagem de investimentos consolidados");

            var investimentos = _investimentoServico.SincronizaInvestimentos();
            var responseModel = _mapper.Map<ConsolidadoModel>(investimentos);

            _logger.LogInformation("Listagem de investimentos consolidados executada com sucesso");

            return Ok(responseModel);
        }
    }
}
