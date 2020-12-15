using AutoFixture;
using Investimentos.Dominio.Entities;

namespace Investimentos.Teste.Base
{
    public abstract class BaseTeste
    {
        protected Fixture _fixture;

        public BaseTeste()
        {
            _fixture = new Fixture();
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            _fixture.Customize<TesouroDireto>(composer => composer.FromFactory(new TesouroDiretoSpecimenBuilder()));
            _fixture.Customize<RendaFixa>(composer => composer.FromFactory(new RendaFixaSpecimenBuilder()));
            _fixture.Customize<Fundo>(composer => composer.FromFactory(new FundoSpecimenBuilder()));
        }
    }
}
