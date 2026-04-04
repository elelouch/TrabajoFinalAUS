namespace MissTortas.Services.DTO.Products
{
    public class ProductCategoryDTO
    {
        public bool IsFinal { get; set; }
        public string Name { get; set; } = string.Empty;
        public long Id { get; set; }
        public List<ProductCategoryDTO> Children { get; set; } = [];
    }
}
