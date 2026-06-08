namespace MissTortas.View.DTO.Products
{
    public class CreateProductCategoryRequest
    {
        public long? ParentId { get; set; }
        public bool IsFinal { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
