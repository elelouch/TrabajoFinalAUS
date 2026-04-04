namespace MissTortas.Presentation.DTO.Products
{
    public class CreateProductCategory
    {
        public long[] ViewerSubjectIds { get; set; } = [];
        public long ParentId { get; set; }
        public bool IsFinal { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
