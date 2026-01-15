using MissTortas.Models.Model.Order;

namespace MissTortas.Models.Model.Product.Product
{
    public class PersonalizedProduct
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public required Consultancy Consultancy { get; set; }
    }
}
