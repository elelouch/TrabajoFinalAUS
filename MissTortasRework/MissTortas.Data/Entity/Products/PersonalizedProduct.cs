using MissTortas.Data.Entity.Orders;

namespace MissTortas.Data.Entity.Products
{
    public class PersonalizedProduct
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public virtual ProductFile? ProductImage { get; set; }
        public float FinalPrice { get; set; }
    }
}
