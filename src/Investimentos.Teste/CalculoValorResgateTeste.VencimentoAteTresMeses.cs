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
        [Fact(DisplayName = "TESOURO DIRETO - Calcula valor para resgate com vencimento menor que 3 meses")]
        [Trait("Categoria", "VALOR RESGATE")]
        public void Tesouro_Direto_Calcula_Valor_Resgate_Vencimento_Menor_Tres_Meses()
        {
            //Given
            var valorInvestido = 100m;
            Aliquota aliquotaEsperada = 0.06m;
            var valorResgateEsperado = valorInvestido - (valorInvestido * aliquotaEsperada.Percentual);
            var totalDiasTresMeses = (365.25 / 12) * 3;
            var vencimento = DateTime.Today.AddDays(totalDiasTresMeses -1);
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

        [Fact(DisplayName = "TESOURO DIRETO - Calcula valor para resgate com vencimento exatamente em 3 meses")]
        [Trait("Categoria", "VALOR RESGATE")]
        public void Tesouro_Direto_Calcula_Valor_Resgate_Vencimento_Exatamente_Tres_Meses()
        {
            //Given
            var valorInvestido = 100m;
            Aliquota aliquotaEsperada = 0.06m;
            var valorResgateEsperado = valorInvestido - (valorInvestido * aliquotaEsperada.Percentual);
            var totalDiasTresMeses = (365.25 / 12) * 3;
            var vencimento = DateTime.Today.AddDays(totalDiasTresMeses);
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

        [Fact(DisplayName = "TESOURO DIRETO - Calcula valor para resgate com vencimento maior que 3 meses")]
        [Trait("Categoria", "VALOR RESGATE")]
        public void Renda_Fixa_Calcula_Valor_Resgate_Vencimento_Maior_Tres_Meses()
        {
            //Given
            var valorInvestido = 100m;
            Aliquota aliquotaEsperada = 0.06m;
            var valorResgateEsperado = valorInvestido - (valorInvestido * aliquotaEsperada.Percentual);
            var totalDiasTresMeses = (365.25 / 12) * 3;
            var vencimento = DateTime.Today.AddDays(totalDiasTresMeses + 1);
            var compra = DateTime.Today;

            //When
            var investimento = Investimento.Factor.Criar<TesouroDireto>(
                nome: _fixture.Create<string>(),
                valorInvestido: valorInvestido,
                valorTotal: _fixture.Create<decimal>(),
                vencimento: vencimento,
                compra: compra);

            //Then
            Assert.NotEqual(valorResgateEsperado, investimento.ValorResgate);
        }

        [Fact(DisplayName = "RENDA FIXA - Calcula valor para resgate com vencimento menor que 3 meses")]
        [Trait("Categoria", "VALOR RESGATE")]
        public void Renda_Fixa_Calcula_Valor_Resgate_Vencimento_Menor_Tres_Meses()
        {
            //Given
            var valorInvestido = 100m;
            Aliquota aliquotaEsperada = 0.06m;
            var valorResgateEsperado = valorInvestido - (valorInvestido * aliquotaEsperada.Percentual);
            var totalDiasTresMeses = (365.25 / 12) * 3;
            var vencimento = DateTime.Today.AddDays(totalDiasTresMeses - 1);
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

        [Fact(DisplayName = "RENDA FIXA - Calcula valor para resgate com vencimento exatamente em 3 meses")]
        [Trait("Categoria", "VALOR RESGATE")]
        public void Renda_Fixa_Calcula_Valor_Resgate_Vencimento_Exatamente_Tres_Meses()
        {
            //Given
            var valorInvestido = 100m;
            Aliquota aliquotaEsperada = 0.06m;
            var valorResgateEsperado = valorInvestido - (valorInvestido * aliquotaEsperada.Percentual);
            var totalDiasTresMeses = (365.25 / 12) * 3;
            var vencimento = DateTime.Today.AddDays(totalDiasTresMeses);
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

        [Fact(DisplayName = "RENDA FIXA - Calcula valor para resgate com vencimento maior que 3 meses")]
        [Trait("Categoria", "VALOR RESGATE")]
        public void Tesouro_Direto_Calcula_Valor_Resgate_Vencimento_Maior_Tres_Meses()
        {
            //Given
            var valorInvestido = 100m;
            Aliquota aliquotaEsperada = 0.06m;
            var valorResgateEsperado = valorInvestido - (valorInvestido * aliquotaEsperada.Percentual);
            var totalDiasTresMeses = (365.25 / 12) * 3;
            var vencimento = DateTime.Today.AddDays(totalDiasTresMeses + 1);
            var compra = DateTime.Today;

            //When
            var investimento = Investimento.Factor.Criar<RendaFixa>(
                nome: _fixture.Create<string>(),
                valorInvestido: valorInvestido,
                valorTotal: _fixture.Create<decimal>(),
                vencimento: vencimento,
                compra: compra);

            //Then
            Assert.NotEqual(valorResgateEsperado, investimento.ValorResgate);
        }

        [Fact(DisplayName = "FUNDO - Calcula valor para resgate com vencimento menor que 3 meses")]
        [Trait("Categoria", "VALOR RESGATE")]
        public void Fundo_Calcula_Valor_Resgate_Vencimento_Menor_Tres_Meses()
        {
            //Given
            var valorInvestido = 100m;
            Aliquota aliquotaEsperada = 0.06m;
            var valorResgateEsperado = valorInvestido - (valorInvestido * aliquotaEsperada.Percentual);
            var totalDiasTresMeses = (365.25 / 12) * 3;
            var vencimento = DateTime.Today.AddDays(totalDiasTresMeses - 1);
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

        [Fact(DisplayName = "FUNDO - Calcula valor para resgate com vencimento exatamente em 3 meses")]
        [Trait("Categoria", "VALOR RESGATE")]
        public void Fundo_Calcula_Valor_Resgate_Vencimento_Exatamente_Tres_Meses()
        {
            //Given
            var valorInvestido = 100m;
            Aliquota aliquotaEsperada = 0.06m;
            var valorResgateEsperado = valorInvestido - (valorInvestido * aliquotaEsperada.Percentual);
            var totalDiasTresMeses = (365.25 / 12) * 3;
            var vencimento = DateTime.Today.AddDays(totalDiasTresMeses);
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

        [Fact(DisplayName = "FUNDO - Calcula valor para resgate com vencimento maior que 3 meses")]
        [Trait("Categoria", "VALOR RESGATE")]
        public void Fundo_Calcula_Valor_Resgate_Vencimento_Maior_Tres_Meses()
        {
            //Given
            var valorInvestido = 100m;
            Aliquota aliquotaEsperada = 0.06m;
            var valorResgateEsperado = valorInvestido - (valorInvestido * aliquotaEsperada.Percentual);
            var totalDiasTresMeses = (365.25 / 12) * 3;
            var vencimento = DateTime.Today.AddDays(totalDiasTresMeses + 1);
            var compra = DateTime.Today;

            //When
            var investimento = Investimento.Factor.Criar<Fundo>(
                nome: _fixture.Create<string>(),
                valorInvestido: valorInvestido,
                valorTotal: _fixture.Create<decimal>(),
                vencimento: vencimento,
                compra: compra);

            //Then
            Assert.NotEqual(valorResgateEsperado, investimento.ValorResgate);
        }
    }
}
