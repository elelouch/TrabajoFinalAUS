namespace MissTortas.Data.Entity.Products
{
    public class SaleProduct : Product
    {
        public required StockProduct StockProduct { get; set; }
        public required ProductImage SaleImage { get; set; }
    }
}
