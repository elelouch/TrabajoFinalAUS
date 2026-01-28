using MissTortas.Data.Entity.Products;

namespace MissTortas.Services.DTO.Products
{
    public class CreateProductDTO
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public long CategoryId { get; set; }
    }
}
