using Investimentos.Dominio.Entities;
using AutoFixture;
using Xunit;
using System;
using Investimentos.Dominio.ValueObjects;
using Investimentos.Dominio.Entities.Base;

namespace Investimentos.Teste
{
    public partial class CalculoValorResgateTeste
    {
        [Fact(DisplayName = "TESOURO DIRETO - Calcula valor para resgate com custódia acima da metade do tempo")]
        [Trait("Categoria", "VALOR RESGATE")]
        public void Tesouro_Direto_Calcula_Valor_Resgate_Custodia_Acima_Metade_Tempo()
        {
            //Given
            var valorInvestido = 100m;
            Aliquota aliquotaEsperada = 0.15m;
            var valorResgateEsperado = valorInvestido - (valorInvestido * aliquotaEsperada.Percentual);
            var vencimento = DateTime.Today.AddDays(1);
            var compra = DateTime.Today.AddDays(-2);

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

        [Fact(DisplayName = "TESOURO DIRETO - Calcula valor para resgate com custódia extamente na metade do tempo")]
        [Trait("Categoria", "VALOR RESGATE")]
        public void Tesouro_Direto_Calcula_Valor_Resgate_Custodia_Exatamente_Na_Metade_Tempo()
        {
            //Given
            var valorInvestido = 100m;
            Aliquota aliquotaEsperada = 0.15m;
            var valorResgateEsperado = valorInvestido - (valorInvestido * aliquotaEsperada.Percentual);
            var vencimento = DateTime.Today.AddDays(1);
            var compra = DateTime.Today.AddDays(-1);

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

        [Fact(DisplayName = "TESOURO DIRETO - Calcula valor para resgate com custódia abaixo da metade do tempo")]
        [Trait("Categoria", "VALOR RESGATE")]
        public void Tesouro_Direto_Calcula_Valor_Resgate_Custodia_Abaixo_Da_Metade_Tempo()
        {
            //Given
            var valorInvestido = 100m;
            Aliquota aliquotaEsperada = 0.15m;
            var valorResgateEsperado = valorInvestido - (valorInvestido * aliquotaEsperada.Percentual);
            var vencimento = DateTime.Today.AddDays(2);
            var compra = DateTime.Today.AddDays(-1);

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

        [Fact(DisplayName = "RENDA FIXA - Calcula valor para resgate com custódia acima da metade do tempo")]
        [Trait("Categoria", "VALOR RESGATE")]
        public void Renda_Fixa_Calcula_Valor_Resgate_Custodia_Acima_Metade_Tempo()
        {
            //Given
            var valorInvestido = 100m;
            Aliquota aliquotaEsperada = 0.15m;
            var valorResgateEsperado = valorInvestido - (valorInvestido * aliquotaEsperada.Percentual);
            var vencimento = DateTime.Today.AddDays(1);
            var compra = DateTime.Today.AddDays(-2);

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

        [Fact(DisplayName = "RENDA FIXA - Calcula valor para resgate com custódia extamente na metade do tempo")]
        [Trait("Categoria", "VALOR RESGATE")]
        public void Renda_Fixa_Calcula_Valor_Resgate_Custodia_Exatamente_Na_Metade_Tempo()
        {
            //Given
            var valorInvestido = 100m;
            Aliquota aliquotaEsperada = 0.15m;
            var valorResgateEsperado = valorInvestido - (valorInvestido * aliquotaEsperada.Percentual);
            var vencimento = DateTime.Today.AddDays(1);
            var compra = DateTime.Today.AddDays(-1);

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

        [Fact(DisplayName = "RENDA FIXA - Calcula valor para resgate com custódia abaixo da metade do tempo")]
        [Trait("Categoria", "VALOR RESGATE")]
        public void Renda_Fixa_Calcula_Valor_Resgate_Custodia_Abaixo_Da_Metade_Tempo()
        {
            //Given
            var valorInvestido = 100m;
            Aliquota aliquotaEsperada = 0.15m;
            var valorResgateEsperado = valorInvestido - (valorInvestido * aliquotaEsperada.Percentual);
            var vencimento = DateTime.Today.AddDays(2);
            var compra = DateTime.Today.AddDays(-1);

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

        [Fact(DisplayName = "FUNDO - Calcula valor para resgate com custódia acima da metade do tempo")]
        [Trait("Categoria", "VALOR RESGATE")]
        public void Fundo_Calcula_Valor_Resgate_Custodia_Acima_Metade_Tempo()
        {
            //Given
            var valorInvestido = 100m;
            Aliquota aliquotaEsperada = 0.15m;
            var valorResgateEsperado = valorInvestido - (valorInvestido * aliquotaEsperada.Percentual);
            var vencimento = DateTime.Today.AddDays(1);
            var compra = DateTime.Today.AddDays(-2);

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

        [Fact(DisplayName = "FUNDO - Calcula valor para resgate com custódia extamente na metade do tempo")]
        [Trait("Categoria", "VALOR RESGATE")]
        public void Fundo_Calcula_Valor_Resgate_Custodia_Exatamente_Na_Metade_Tempo()
        {
            //Given
            var valorInvestido = 100m;
            Aliquota aliquotaEsperada = 0.15m;
            var valorResgateEsperado = valorInvestido - (valorInvestido * aliquotaEsperada.Percentual);
            var vencimento = DateTime.Today.AddDays(1);
            var compra = DateTime.Today.AddDays(-1);

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

        [Fact(DisplayName = "FUNDO - Calcula valor para resgate com custódia abaixo da metade do tempo")]
        [Trait("Categoria", "VALOR RESGATE")]
        public void Fundo_Calcula_Valor_Aliquota_Resgate_Custodia_Abaixo_Da_Metade_Tempo()
        {
            //Given
            var valorInvestido = 100m;
            Aliquota aliquotaEsperada = 0.15m;
            var valorResgateEsperado = valorInvestido - (valorInvestido * aliquotaEsperada.Percentual);
            var vencimento = DateTime.Today.AddDays(2);
            var compra = DateTime.Today.AddDays(-1);

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
