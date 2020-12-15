namespace Investimentos.Dominio.ValueObjects
{
    public struct Aliquota
    {
        public decimal Percentual { get; set; }

        public Aliquota(decimal percentual)
        {
            Percentual = percentual;
        }

        public static implicit operator Aliquota(decimal aliquota)
        {
            return new Aliquota(aliquota);
        }
    }
}
