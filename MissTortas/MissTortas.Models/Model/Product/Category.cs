namespace MissTortas.Models.Model.Product
{
    public abstract class Category
    {
        public abstract long Id { get; set; }
        public abstract string Name { get; set; }
        public abstract List<Category> ChildrenCategory { get; set; }
        public abstract bool IsFinal { get; set; }
        public abstract Category? Parent { get; set; }
    }
}
