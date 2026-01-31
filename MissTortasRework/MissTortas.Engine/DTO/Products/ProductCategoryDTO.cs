namespace MissTortas.Engine.DTO.Products
{
    public class ProductCategoryDTO
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public long ParentId { get; set; }
    }
}
