namespace MissTortasEngine.Model.Product
{
    public class ProductCategory : Category
    {
        public override long Id { get; set; }
        public override string Name { get; set; } = string.Empty;
        public override required List<Category> ChildrenCategory { get; set; }
        public override bool IsFinal { get; set; }
        public override Category? Parent { get; set; }
        public required List<ProductBase> Products { get; set; }
    }
}
