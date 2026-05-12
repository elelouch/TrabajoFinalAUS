namespace MissTortas.Domain.Security.Authorization
{
    public abstract class Subject : IHasResource
    {
        public long SubjectId { get; set; }
        public ICollection<Right> Rights { get; set; } = [];
        public long ResourceId { get; set; }
        public Resource Resource { get; set; } = default!;
    }
}
