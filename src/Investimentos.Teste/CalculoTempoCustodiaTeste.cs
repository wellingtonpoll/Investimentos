using System;
using Xunit;

namespace Investimentos.Teste
{
    public class CalculoTempoCustodiaTeste
    {
        [Theory(DisplayName = "Investimento com mais da metade do tempo em custódia")]
        [Trait("Categoria", "Tempo em Custódia")]
        [InlineData("2020-12-01", "2020-12-16", "2020-12-31")]
        [InlineData("2020-12-01", "2020-12-15", "2020-12-31")]
        public void Aliquota_De_15_Porcento_Para_Mais_Da_Metade_Do_Tempo_Em_Custodia(string dataCompra, string dataResgate, string dataVencimento)
        {
            //Given
            var _dataCompra = DateTime.Parse(dataCompra);
            var _dataResgate = DateTime.Parse(dataResgate);
            var _dataVencimento = DateTime.Parse(dataVencimento);
            var _percentualDePerdaDoValorInvestido = 0m;
            var _percentualDePerdaDoValorInvestidoEsperado = 15;
            //When

            var custodiaEmDiasRelativoAhCompra = _dataVencimento.Subtract(_dataCompra).TotalDays;
            var metadeCustodiaEmDiasRelativoAhCompra = Math.Truncate(custodiaEmDiasRelativoAhCompra / 2);
            var custodiaEmDiasRelativoAhDataResgate = _dataResgate.Subtract(_dataCompra).TotalDays;

            if (custodiaEmDiasRelativoAhDataResgate >= metadeCustodiaEmDiasRelativoAhCompra)
                _percentualDePerdaDoValorInvestido = 15;

            //Then
            Assert.Equal(_percentualDePerdaDoValorInvestidoEsperado, _percentualDePerdaDoValorInvestido);
        }
    }
}
