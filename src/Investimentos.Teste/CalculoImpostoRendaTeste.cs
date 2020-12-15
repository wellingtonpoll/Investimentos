using Investimentos.Dominio.Entities;
using Xunit;
using AutoFixture;
using Investimentos.Teste.Base;
using Investimentos.Dominio.ValueObjects;

namespace Investimentos.Teste
{
    public class CalculoImpostoRendaTeste : BaseTeste
    {
        [Fact(DisplayName = "TESOURO DIRETO - Calcula valor do imposto de renda")]
        [Trait("Categoria", "IMPOSTO DE RENDA")]
        public void Tesouro_Direto_Calcula_Imposto_Renda()
        {
            //Given
            var investimento = _fixture.Create<TesouroDireto>();
            var aliquota = new Aliquota(0.1m);
            var valorImpostoRendaEsperado = investimento.Rentabilidade * aliquota.Percentual;

            //When
            investimento.CalculaImpostoRenda();

            //Then
            Assert.Equal(valorImpostoRendaEsperado, investimento.ValorImpostoRenda);
        }

        [Fact(DisplayName = "RENDA FIXA - Calcula valor do imposto de renda")]
        [Trait("Categoria", "IMPOSTO DE RENDA")]
        public void Renda_Fixa_Calcula_Imposto_Renda()
        {
            //Given
            var investimento = _fixture.Create<RendaFixa>();
            var aliquota = new Aliquota(0.05m);
            var valorImpostoRendaEsperado = investimento.Rentabilidade * aliquota.Percentual;

            //When
            investimento.CalculaImpostoRenda();

            //Then
            Assert.Equal(valorImpostoRendaEsperado, investimento.ValorImpostoRenda);
        }

        [Fact(DisplayName = "FUNDO - Calcula valor do imposto de renda")]
        [Trait("Categoria", "IMPOSTO DE RENDA")]
        public void Fundo_Calcula_Imposto_Renda()
        {
            //Given
            var investimento = _fixture.Create<Fundo>();
            var aliquota = new Aliquota(0.15m);
            var valorImpostoRendaEsperado = investimento.Rentabilidade * aliquota.Percentual;

            //When
            investimento.CalculaImpostoRenda();

            //Then
            Assert.Equal(valorImpostoRendaEsperado, investimento.ValorImpostoRenda);
        }
    }
}
