namespace MissTortas.Domain.Security.Authorization
{
    public abstract class Subject
    {
        public long SubjectId { get; set; }
        public ICollection<Right> Rights { get; set; } = [];
    }
}
