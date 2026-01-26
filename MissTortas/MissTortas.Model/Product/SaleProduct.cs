namespace MissTortas.Models.Product
{
    public class SaleProduct : ProductBase
    {
        public override long Id { get; set; }
        public override string Name { get; set; } = string.Empty;
        public override string Description { get; set; } = string.Empty;
        public StockProduct StockProduct { get; set; }
        public ProductImage SaleImage { get; set; }
        public SaleProduct() { }
    }
}
