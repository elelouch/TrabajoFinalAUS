namespace Misstortas.Frontend.Models
{
    public class Category
    {
        public string Name { get; set; } = "";
        public Category[] Children { get; set; } = [];
        public Product[] Products { get; set; } = [];
    }
}
