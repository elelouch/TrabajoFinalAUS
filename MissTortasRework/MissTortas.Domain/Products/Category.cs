using MissTortas.Domain.Security.Authorization;

namespace MissTortas.Domain.Products
{
    public abstract class Category : Resource
    {
        public string Name { get; set; } = string.Empty;
        public bool IsFinal { get; set; }
        public virtual ICollection<Category> Children { get; set; } = [];
        public long ParentId { get; set; }
        public virtual Category? Parent { get; set; }
    }
}
