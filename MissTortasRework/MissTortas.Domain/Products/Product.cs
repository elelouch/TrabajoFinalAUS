using MissTortas.Domain.Security.Authorization;

namespace MissTortas.Domain.Products
{
    public class Product : Resource
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public virtual required ProductDetail ProductDetail { get; set; }
        public virtual required ProductCategory ProductCategory { get; set; }
        public virtual SaleProduct? SaleProduct { get; set; }
        public double Quantity { get; set; }
        public bool ManageQuantityAsInteger { get; set; }
        public string Unit { get; set; } = string.Empty;
    }
}
