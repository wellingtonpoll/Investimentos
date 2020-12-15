using AutoFixture;
using Investimentos.Dominio.Entities;
using Investimentos.Infra.Cache.Interfaces;
using Investimentos.Infra.Rest;
using Moq;
using RestSharp;

namespace Investimentos.Teste.Base
{
    public abstract class BaseTeste
    {
        protected const string _fakeUrl = "http://127.0.0.1";
        protected Mock<IRestClient> _mockRestClient;
        protected Mock<IRestManager> _mockRestManager;
        protected Mock<ICacheManager> _mockCacheManager;
        protected Fixture _fixture;

        public BaseTeste()
        {
            _fixture = new Fixture();
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            _fixture.Customize<TesouroDireto>(composer => composer.FromFactory(new TesouroDiretoSpecimenBuilder()));
            _fixture.Customize<RendaFixa>(composer => composer.FromFactory(new RendaFixaSpecimenBuilder()));
            _fixture.Customize<Fundo>(composer => composer.FromFactory(new FundoSpecimenBuilder()));

            _mockRestClient = new Mock<IRestClient>();
            _mockCacheManager = new Mock<ICacheManager>();
            _mockRestManager = new Mock<IRestManager>();
        }
    }
}
