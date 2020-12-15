using System;

namespace Investimentos.Infra.Cache.Exceptions
{
    public class CacheProviderNaoImplementadoException : Exception
    {
        public CacheProviderNaoImplementadoException()
            : base("Nenhuma implementação de ICacheProvider foi encontrada para a injeção de dependência da interface ICacheManager!")
        {

        }
    }
}
