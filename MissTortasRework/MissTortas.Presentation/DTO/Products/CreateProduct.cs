using MissTortas.Data.Entity.Products;

namespace MissTortas.Presentation.DTO.Products
{
    public class CreateProduct
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public long CategoryId { get; set; }
        public bool ManageQuantityAsInteger { get; set; }
        public double Quantity { get; set; }
    }
}
