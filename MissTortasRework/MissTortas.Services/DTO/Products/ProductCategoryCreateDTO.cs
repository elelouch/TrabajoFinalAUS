namespace MissTortas.Services.DTO.Products
{
    public class ProductCategoryCreateDTO
    {
        public long[] ViewerSubjectsIds { get; set; } = [];
        public long ParentId { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsFinal { get; set; }
    }
}
