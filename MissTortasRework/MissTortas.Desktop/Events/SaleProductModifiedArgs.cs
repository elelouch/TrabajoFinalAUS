using MissTortas.Desktop.Model;

namespace MissTortas.Desktop.Events
{
    public class SaleProductModifiedArgs(SaleProduct sp)
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
