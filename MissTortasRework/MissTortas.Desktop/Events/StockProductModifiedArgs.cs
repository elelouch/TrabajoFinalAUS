using MissTortas.Desktop.Model;

namespace MissTortas.Desktop.Events
{
    public class StockProductModifiedArgs(Product product)
    {
        public Product Product
        {
            get
            {
                return product;
            }
        }
    }
}
