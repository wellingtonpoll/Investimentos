using Investimentos.Dominio.ValueObjects;
using MongoDB.Bson;
using System;

namespace Investimentos.Dominio.Entities.Base
{
    public abstract partial class Investimento
    {
        protected Investimento() {}
        public abstract Aliquota AliquotaIR { get; }
        
        public string CodigoUsuario { get; protected set; }
        public string Nome { get; protected set; }
        public decimal ValorInvestido { get; protected set; }
        public decimal ValorTotal { get; protected set; }
        public DateTime Vencimento { get; protected set; }
        public DateTime Compra { get; protected set; }
        public decimal ValorImpostoRenda { get; protected set; }
        public decimal ValorResgate { get; protected set; }
        public decimal Rentabilidade { get { return ValorTotal - ValorInvestido; } }

        public virtual void CalculaImpostoRenda()
        {
            ValorImpostoRenda = Rentabilidade * AliquotaIR.Percentual;
        }

        protected virtual Aliquota CalculaAliquotaParaResgate()
        {
            // Aliquota padrão
            Aliquota aliquotaParaResgate = 0.30M;

            if (MaisDaMetadeDoTempoEmCustodia())
                aliquotaParaResgate = 0.15m;
            else if (VencimentoOcorreEmAteTresMeses())
                aliquotaParaResgate = 0.06m;

            return aliquotaParaResgate;
        }

        public virtual void CalculaValorResgate()
        {
            var aliquotaParaResgate = CalculaAliquotaParaResgate();
            var valorAhAbater = ValorInvestido * aliquotaParaResgate.Percentual;
            ValorResgate = ValorInvestido - valorAhAbater;
        }

        private bool VencimentoOcorreEmAteTresMeses()
        {
            var mesesParaVencer = Vencimento.Subtract(DateTime.Today).Days / (365.25 / 12);
            return mesesParaVencer <= 3;
        }

        private bool MaisDaMetadeDoTempoEmCustodia()
        {
            var custodiaEmDiasRelativoAhCompra = Vencimento.Subtract(Compra).TotalDays;
            var metadeCustodiaEmDiasRelativoAhCompra = Math.Truncate(custodiaEmDiasRelativoAhCompra / 2);
            var custodiaEmDiasRelativoAhDataResgate = DateTime.Today.Subtract(Compra).TotalDays;

            return custodiaEmDiasRelativoAhDataResgate >= metadeCustodiaEmDiasRelativoAhCompra;
        }
    }
}
