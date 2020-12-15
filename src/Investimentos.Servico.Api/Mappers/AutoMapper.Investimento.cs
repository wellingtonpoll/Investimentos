using Investimentos.Dominio.Entities.Base;
using Investimentos.Servico.Api.Models;

namespace Investimentos.Servico.Api.Mappers
{
    public partial class AutoMapper
    {
        private void MapInvestimento()
        {
            CreateMap<Investimento, InvestimentoModel>()
                .ForMember(model => model.Ir, option => option.MapFrom(investimento => investimento.ValorImpostoRenda));
        }
    }
}
