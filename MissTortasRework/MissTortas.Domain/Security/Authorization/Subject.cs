namespace MissTortas.Domain.Security.Authorization
{
    public abstract class Subject
    {
        public long Id { get; set; }
        public ICollection<Right> Rights { get; set; } = [];
    }
}
