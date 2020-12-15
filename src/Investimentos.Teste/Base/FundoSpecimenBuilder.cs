using AutoFixture;
using AutoFixture.Kernel;
using Investimentos.Dominio.Entities;
using Investimentos.Dominio.Entities.Base;
using System;

namespace Investimentos.Teste.Base
{
    public class FundoSpecimenBuilder : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            return
                Investimento.Factor.Criar<Fundo>(
                    context.Create<string>(),
                    context.Create<decimal>(),
                    context.Create<decimal>(),
                    context.Create<DateTime>(),
                    context.Create<DateTime>());
        }
    }
}
