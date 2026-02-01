using MissTortas.Data.Entity.Orders;

namespace MissTortas.Data.Entity.Products
{
    public class PersonalizedProduct
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public required Consultancy Consultancy { get; set; }
        public required ProductCategory ProductCategory { get; set; }
        public float FinalPrice { get; set; }
    }
}
