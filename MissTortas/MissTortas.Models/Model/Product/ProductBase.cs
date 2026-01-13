namespace MissTortasEngine.Model.Product
{
    public abstract class ProductBase
    {
        public abstract string Name { get; set; } 
        public abstract long Id { get; set; }
        public abstract string Description { get; set; }
    }
}
