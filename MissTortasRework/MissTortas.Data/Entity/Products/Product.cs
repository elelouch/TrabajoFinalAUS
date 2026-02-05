namespace MissTortas.Data.Entity.Products
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public virtual required ProductDetail ProductDetail { get; set; }
        public virtual required ProductCategory ProductCategory { get; set; }
        public SaleProduct? SaleProduct { get; set; }
        public double DecimalQuantity { get; set; }
        public long Quantity { get; set; }
        public bool AllowDecimal { get; set; }
        public string Unit { get; set; } = string.Empty;
    }
}
