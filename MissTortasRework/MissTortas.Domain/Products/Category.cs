using MissTortas.Domain.Security.Authorization;

namespace MissTortas.Domain.Products
{
    public abstract class Category : Resource
    {
        public abstract string Name { get; set; }
        public abstract bool IsFinal { get; set; }
    }
}
