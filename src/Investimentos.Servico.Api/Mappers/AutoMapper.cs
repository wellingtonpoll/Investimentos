using AutoMapper;

namespace Investimentos.Servico.Api.Mappers
{
    public partial class AutoMapper : Profile
    {
        public AutoMapper()
        {
            MapInvestimento();
            MapInvestimentoConsolidado();
        }
    }
}
