namespace MissTortas.Domain.Security.Authorization
{
    public abstract class Resource
    {
        public long ResourceId { get; set; }
        public ICollection<Right> Rights { get; set; } = [];
    }
}
