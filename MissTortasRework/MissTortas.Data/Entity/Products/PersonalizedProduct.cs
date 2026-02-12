using MissTortas.Data.Entity.Orders;

namespace MissTortas.Data.Entity.Products
{
    public class PersonalizedProduct
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public long ConsultancyId { get; set; }
        public virtual required Consultancy Consultancy { get; set; }
        public virtual required ProductCategory ProductCategory { get; set; }
        public float FinalPrice { get; set; }
    }
}
