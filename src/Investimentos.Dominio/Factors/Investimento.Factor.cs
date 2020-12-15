using System;

namespace Investimentos.Dominio.Entities.Base
{
    public abstract partial class Investimento
    {
        public static class Factor
        {
            public static TInvestimento Criar<TInvestimento>(
                string nome,
                decimal valorInvestido,
                decimal valorTotal,
                DateTime vencimento,
                DateTime compra)
                    where TInvestimento : Investimento
            {
                var investimento = Activator.CreateInstance<TInvestimento>();
                investimento.Nome = nome;
                investimento.ValorInvestido = valorInvestido;
                investimento.ValorTotal = valorTotal;
                investimento.Vencimento = vencimento;
                investimento.Compra = compra;

                investimento.CalculaImpostoRenda();
                investimento.CalculaValorResgate();

                return investimento;
            }
        }
    }
}
