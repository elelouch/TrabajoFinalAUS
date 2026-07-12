using MissTortas.Desktop.Model;

namespace MissTortas.Desktop.Events
{
    public class CategoryCreatedArgs(ProductCategory cat)
    {
        public ProductCategory Category
        {
            get
            {
                return cat;
            }
        }
    }
}
