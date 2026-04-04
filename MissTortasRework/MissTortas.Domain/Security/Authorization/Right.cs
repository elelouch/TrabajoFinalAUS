namespace MissTortas.Domain.Security.Authorization
{
    public class Right
    {
        public required bool Transferable { get; set; }
        public bool Constraint { get; set; }
        public required AccessType AccessType { get; set; }
        public long SubjectId { get; set; }
        public Subject Subject { get; set; }
        public long ResourceId { get; set; }
        public Resource Resource { get; set; }
    }
}
