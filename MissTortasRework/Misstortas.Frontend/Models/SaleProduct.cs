namespace Misstortas.Frontend.Models
{
    public class SaleProduct
    {
        public long Id { get; set; } 
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public double Quantity { get; set; }
        public bool AllowDecimalAsk { get; set; }
    }
}