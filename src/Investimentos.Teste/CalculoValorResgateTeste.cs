using Investimentos.Dominio.Entities;
using Investimentos.Dominio.Entities.Base;
using Investimentos.Dominio.ValueObjects;
using Investimentos.Teste.Base;
using AutoFixture;
using System;
using Xunit;

namespace Investimentos.Teste
{
    public partial class CalculoValorResgateTeste : BaseTeste
    {
        [Fact(DisplayName = "TESOURO DIRETO - Calcula valor para resgate padrao")]
        [Trait("Categoria", "VALOR RESGATE")]
        public void Tesouro_Direto_Calcula_Valor_Resgate_Padrao()
        {
            //Given
            var valorInvestido = 100m;
            Aliquota aliquotaEsperada = 0.3m;
            var valorResgateEsperado = valorInvestido - (valorInvestido * aliquotaEsperada.Percentual);
            var vencimento = DateTime.Today.AddYears(1);
            var compra = DateTime.Today;

            //When
            var investimento = Investimento.Factor.Criar<TesouroDireto>(
                nome: _fixture.Create<string>(),
                valorInvestido: valorInvestido,
                valorTotal: _fixture.Create<decimal>(),
                vencimento: vencimento,
                compra: compra);

            //Then
            Assert.Equal(valorResgateEsperado, investimento.ValorResgate);
        }

        [Fact(DisplayName = "RENDA FIXA - Calcula valor para resgate padrao")]
        [Trait("Categoria", "VALOR RESGATE")]
        public void Renda_Fixa_Calcula_Valor_Resgate_Padrao()
        {
            //Given
            var valorInvestido = 100m;
            Aliquota aliquotaEsperada = 0.3m;
            var valorResgateEsperado = valorInvestido - (valorInvestido * aliquotaEsperada.Percentual);
            var vencimento = DateTime.Today.AddYears(1);
            var compra = DateTime.Today;

            //When
            var investimento = Investimento.Factor.Criar<RendaFixa>(
                nome: _fixture.Create<string>(),
                valorInvestido: valorInvestido,
                valorTotal: _fixture.Create<decimal>(),
                vencimento: vencimento,
                compra: compra);

            //Then
            Assert.Equal(valorResgateEsperado, investimento.ValorResgate);
        }

        [Fact(DisplayName = "FUNDO - Calcula valor para resgate padrao")]
        [Trait("Categoria", "VALOR RESGATE")]
        public void Fundo_Calcula_Valor_Resgate_Padrao()
        {
            //Given
            var valorInvestido = 100m;
            Aliquota aliquotaEsperada = 0.3m;
            var valorResgateEsperado = valorInvestido - (valorInvestido * aliquotaEsperada.Percentual);
            var vencimento = DateTime.Today.AddYears(1);
            var compra = DateTime.Today;

            //When
            var investimento = Investimento.Factor.Criar<Fundo>(
                nome: _fixture.Create<string>(),
                valorInvestido: valorInvestido,
                valorTotal: _fixture.Create<decimal>(),
                vencimento: vencimento,
                compra: compra);

            //Then
            Assert.Equal(valorResgateEsperado, investimento.ValorResgate);
        }
    }
}
