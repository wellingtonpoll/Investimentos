using Investimentos.Dominio.Entities.Base;
using Investimentos.Dominio.ValueObjects;

namespace Investimentos.Dominio.Entities
{
    public class Fundo : Investimento
    {
        public override Aliquota AliquotaIR { get { return new Aliquota(0.15m); } }
    }
}