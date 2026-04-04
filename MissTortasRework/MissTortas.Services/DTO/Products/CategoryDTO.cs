namespace MissTortas.Services.DTO.Products
{
    public class CategoryDTO
    {
        public bool IsFinal { get; set; }
        public string Name { get; set; } = string.Empty;
        public long ParentId { get; set; }
        public long Id { get; set; }
        public List<CategoryDTO> Children { get; set; } = [];
    }
}
