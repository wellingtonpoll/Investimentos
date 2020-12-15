using System.Collections.Generic;

namespace Investimentos.Servico.Api.Models
{
    public class ConsolidadoModel
    {
        public ConsolidadoModel()
        {
            Investimentos = new List<InvestimentoModel>();
        }

        public decimal ValorTotal { get; set; }
        public IEnumerable<InvestimentoModel> Investimentos { get; set; }
    }
}
