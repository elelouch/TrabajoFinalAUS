using MissTortas.Data.Entity.Orders;

namespace MissTortas.Data.Entity.Products
{
    public class PersonalizedProduct : Product
    {
        public required Consultancy Consultancy { get; set; }
    }
}
