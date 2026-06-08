namespace Misstortas.Frontend.Models
{
    public class SaleProductCartEntry
    {
        public SaleProduct Product { get; init; } = default!;
        public decimal QuantityAsked { get; set; }
    }
}
