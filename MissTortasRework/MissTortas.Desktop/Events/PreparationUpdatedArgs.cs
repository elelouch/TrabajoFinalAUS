using MissTortas.Desktop.Model;

namespace MissTortas.Desktop.Events
{
    public class PreparationUpdatedArgs(Preparation prep)
    {
        public Preparation Preparation
        {
            get
            {
                return prep;
            }
        }
    }
}
