using Investimentos.Dominio.Entities.Base;
using Investimentos.Dominio.ValueObjects;

namespace Investimentos.Dominio.Entities
{
    public partial class TesouroDireto : Investimento
    {
        public override Aliquota AliquotaIR { get { return new Aliquota(0.1m); } }
    }
}
