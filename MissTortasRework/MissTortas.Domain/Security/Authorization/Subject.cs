namespace MissTortas.Domain.Security.Authorization
{
    public abstract class Subject
    {
        public IEnumerable<Right> Rights { get; set; } = [];
    }
}
