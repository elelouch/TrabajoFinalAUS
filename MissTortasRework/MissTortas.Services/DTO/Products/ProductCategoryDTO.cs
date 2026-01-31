namespace MissTortas.Services.DTO.Products
{
    public class ProductCategoryDTO
    {
        public long ParentId { get; set; }
        public bool IsFinal { get; set; }
        public string Name { get; set; } = string.Empty;
        public long Id { get; set; }
        public required IEnumerable<ChildrenProductCategory> Children { get; set; }
    }
}
