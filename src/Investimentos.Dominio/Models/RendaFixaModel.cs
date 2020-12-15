using Investimentos.Dominio.Entities;
using Investimentos.Dominio.Entities.Base;
using System;
using System.Collections.Generic;

namespace Investimentos.Dominio.Models
{
    public class ColecaoRendaFixaModel
    {
        public IEnumerable<RendaFixaModel> Lcis { get; set; }
    }

    public class RendaFixaModel
    {
        public decimal CapitalInvestido { get; set; }
        public decimal CapitalAtual { get; set; }
        public decimal Quantidade { get; set; }
        public DateTime Vencimento { get; set; }
        public decimal IoF { get; set; }
        public decimal OutrasTaxas { get; set; }
        public decimal Taxas { get; set; }
        public string Indice { get; set; }
        public string Tipo { get; set; }
        public string Nome { get; set; }
        public bool GuarantidoFGC { get; set; }
        public DateTime DataOperacao { get; set; }
        public decimal PrecoUnitario { get; set; }
        public bool Primario { get; set; }

        public RendaFixa ConverteParaEntidade()
        {
            return
                Investimento.Factor.Criar<RendaFixa>(
                        Nome,
                        CapitalInvestido,
                        CapitalAtual,
                        Vencimento,
                        DataOperacao);
        }
    }
}
