namespace MissTortas.Engine.DTO.Products
{
    public class CreateProductCategoryDTO
    {
        public long ParentId { get; set; }
        public bool IsFinal { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
