namespace MissTortas.Domain.Security.Authorization
{
    public abstract class Resource
    {
        public IEnumerable<Right> Rights { get; set; } = [];
    }
}
