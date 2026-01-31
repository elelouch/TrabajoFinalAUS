namespace MissTortas.Services.DTO.Products
{
    public class ProductCreateDTO
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public long CategoryId { get; set; }
    }
}
