namespace MissTortas.Domain.Security.Authorization
{
    public abstract class Resource
    {
        public long Id { get; set; }
        public ICollection<Right> Rights { get; set; } = [];
    }
}
