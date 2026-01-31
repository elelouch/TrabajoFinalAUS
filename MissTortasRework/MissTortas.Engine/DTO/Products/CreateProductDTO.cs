using MissTortas.Data.Entity.Products;

namespace MissTortas.Engine.DTO.Products
{
    public class CreateProductDTO
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public long CategoryId { get; set; }
    }
}
