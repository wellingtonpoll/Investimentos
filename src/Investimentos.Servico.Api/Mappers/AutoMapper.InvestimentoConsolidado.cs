using Investimentos.Dominio.Entities.Base;
using Investimentos.Servico.Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace Investimentos.Servico.Api.Mappers
{
    public partial class AutoMapper
    {
        private void MapInvestimentoConsolidado()
        {
            CreateMap<IEnumerable<Investimento>, ConsolidadoModel>()
                .ForMember(model => model.Investimentos, option => option.MapFrom(investimentos => investimentos))
                .ForMember(model => model.ValorTotal, option => option.MapFrom(investimentos => investimentos.Sum(investimento => investimento.ValorTotal)));
        }
    }
}
