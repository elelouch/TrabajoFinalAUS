namespace MissTortas.Data.Entity.Products
{
    public abstract class Category
    {
        public abstract string Name { get; set; }
        public abstract bool IsFinal { get; set; }
    }
}
