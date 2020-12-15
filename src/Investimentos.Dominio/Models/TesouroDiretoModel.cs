using Investimentos.Dominio.Entities;
using Investimentos.Dominio.Entities.Base;
using System;
using System.Collections.Generic;

namespace Investimentos.Dominio.Models
{
    public class ColecaoTesouroDiretoModel
    {
        public IEnumerable<TesouroDiretoModel> Tds { get; set; }
    }

    public class TesouroDiretoModel
    {
        public decimal ValorInvestido { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime Vencimento { get; set; }
        public DateTime DataDeCompra { get; set; }
        public int IoF { get; set; }
        public string Indice { get; set; }
        public string Tipo { get; set; }
        public string Nome { get; set; }

        public TesouroDireto ConverteParaEntidade()
        {
            return
                Investimento.Factor.Criar<TesouroDireto>(
                        Nome,
                        ValorInvestido,
                        ValorTotal,
                        Vencimento,
                        DataDeCompra);
        }
    }
}
