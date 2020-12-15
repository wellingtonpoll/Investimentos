using Investimentos.Dominio.Entities.Base;
using Investimentos.Dominio.ValueObjects;

namespace Investimentos.Dominio.Entities
{
    public class RendaFixa : Investimento
    {
        public override Aliquota AliquotaIR { get { return new Aliquota(0.05m); } }
    }
}
