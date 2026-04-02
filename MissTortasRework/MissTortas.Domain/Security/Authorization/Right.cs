namespace MissTortas.Domain.Security.Authorization
{
    public class Right
    {
        public bool Transferable { get; set; }
        public bool Constraint { get; set; }
        public required AccessType AccessType { get; set; }
    }
}
