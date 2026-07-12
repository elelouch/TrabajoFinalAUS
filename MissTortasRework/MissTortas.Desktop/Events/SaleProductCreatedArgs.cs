using MissTortas.Desktop.Model;

namespace MissTortas.Desktop.Events
{
    public class SaleProductCreatedArgs(SaleProduct sp)
    {
        public SaleProduct SaleProduct
        {
            get
            {
                return sp;
            }
        }
    }
}
