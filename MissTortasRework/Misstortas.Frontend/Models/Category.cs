namespace Misstortas.Frontend.Models
{
    public class Category
    {
        public long? ParentId { get; set; }
        public long ProductCategoryId { get; set; }
        public string Name { get; set; } = "";
        public bool Enabled { get; set; }
        public Category[] Children { get; set; } = [];
        public bool IsFinal { get; set; }
    }
}
