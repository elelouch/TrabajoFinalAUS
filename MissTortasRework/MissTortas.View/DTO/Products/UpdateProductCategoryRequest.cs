namespace MissTortas.View.DTO.Products
{
    public class UpdateProductCategoryRequest
    {
        public string? Name { get; set; }
        public long? ParentId { get; set; }
        public bool? Enabled { get; set; }
    }
}
