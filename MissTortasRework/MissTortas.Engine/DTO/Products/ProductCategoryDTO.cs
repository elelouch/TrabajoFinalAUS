namespace MissTortas.Engine.DTO.Products
{
    public class ProductCategoryDTO
    {
        public long ParentId { get; set; }
        public bool IsFinal { get; set; }
        public string Name { get; set; } = string.Empty;
        public long Id { get; set; }
    }
}
