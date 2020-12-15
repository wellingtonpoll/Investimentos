using Investimentos.Dominio.Entities;
using Investimentos.Dominio.Entities.Base;
using System;
using System.Collections.Generic;

namespace Investimentos.Dominio.Models
{
    public class ColecaoFundoModel
    {
        public IEnumerable<FundoModel> Fundos { get; set; }
    }

    public class FundoModel
    {
        public decimal CapitalInvestido { get; set; }
        public decimal ValorAtual { get; set; }
        public DateTime DataResgate { get; set; }
        public DateTime DataCompra { get; set; }
        public int IoF { get; set; }
        public string Nome { get; set; }
        public decimal TotalTaxas { get; set; }
        public int Quantity { get; set; }

        public Fundo ConverteParaEntidade()
        {
            return
                Investimento.Factor.Criar<Fundo>(
                        Nome,
                        CapitalInvestido,
                        ValorAtual,
                        DataResgate,
                        DataCompra);
        }
    }
}
